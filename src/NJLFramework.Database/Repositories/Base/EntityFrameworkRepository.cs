﻿/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Repository`.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-12 17:01:29
//----------------------------------------------------------------*/



using NJLFramework.Base;
using NJLFramework.Config;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NJLFramework.Database
{
    #region 实体操作基类,一般不被自定义类继承

    /// <summary>
    /// 此类为实体操作基类,不应该被其他类继承
    /// </summary>
    /// <typeparam name="TService">IRepository</typeparam>
    public class EntityFrameworkRepositoryBase<TService> : IRepository<TService>
        where TService: EntityFrameworkRepositoryBase<TService>
    {
        ILogger _logger;
        object _lock = new object();
        
        public EntityFrameworkRepositoryBase(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;

            var loggerFactory = FrameworkConfig.IocConfig.Resolve<ILoggerFactory>();
            _logger = loggerFactory.CreateLogger(nameof(EntityFrameworkRepository));
        }

        /// <summary>
        /// 创建只读库储
        /// </summary>
        /// <returns></returns>
        protected void CreateReadonlyDbContext()
        {
            if (ReadonlyDbContext == null)
            {
                lock (_lock)
                {
                    if (ReadonlyDbContext == null)
                    {
                        var connectionString = ConnectionStringManager.GetReadOnlyConnectionString();
                        var builder = new DbContextOptionsBuilder();
                        builder.UseSqlServer(connectionString);
                        ReadonlyDbContext = new ApplicationDbContext(builder.Options);
                    }
                }
            }
        }

        /// <summary>
        /// 可读可写的dbcontext
        /// </summary>
        public ApplicationDbContext DbContext { get; private set; }

        /// <summary>
        /// 只用于读的dbcontext
        /// </summary>
        public ApplicationDbContext ReadonlyDbContext { get; private set; }
        
        public TService Add<TModel>(TModel entity) where TModel : class, IEntity<TModel>, new()
        {
            try
            {
                DbContext.Entry(entity).State = EntityState.Added;
                return this as TService;
            }
            catch (Exception ex)
            {
                DbContext.Attach(entity).State = EntityState.Unchanged;
                throw ex;
            }
        }

        /// <summary>
        /// 批量新增，非事务性操作
        /// </summary>
        /// <typeparam name="TModel">实体类型</typeparam>
        /// <param name="entities">实体</param>
        /// <returns></returns>
        public async Task BulkAdd<TModel>(List<TModel> entities) where TModel : class, IEntity<TModel>, new()
        {
            var connectionString = DbContext.Database.GetDbConnection().ConnectionString;

            _logger.LogWarning(Resource.ResourceManager.GetString("WARN_BULK_ADD_MYBE_SLOW"));

            if (entities.Count <= 100 * 10000)
            {
                await ByBatchBulkAdd(connectionString, entities);
            }
            else
            {
                //获取核心数,按核心数并行计算
                var coreCount = Environment.ProcessorCount;
                var size = entities.Count / coreCount;
                var handled = size * coreCount;
                var noHandled = entities.Count - size * coreCount;
                var noHnadledEntities = new List<TModel>();
                if (noHandled > 0)
                {
                    noHnadledEntities = entities.Skip(handled).Take(noHandled).ToList();
                }
                Parallel.For(0, coreCount, async i =>
                {
                    var list = entities.Skip(i * size).Take(size).ToList();
                    if (noHnadledEntities.Count > 0 && i == (coreCount - 1))
                    {
                        list.AddRange(noHnadledEntities);
                    }
                    await ByBatchBulkAdd(connectionString, list);
                });
            }
        }

        /// <summary>
        /// 按批批量新增
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        #pragma warning disable 1998
        protected virtual async Task ByBatchBulkAdd<TModel>(string connectionString,
            List<TModel> entities)
        {
#if NET451 || DNX451
            DataTable table = new DataTable();
            DataRow tmpDr = null;
            PropertyInfo propInfo;
            var type = typeof(TModel);
            SqlBulkCopy bulk = new SqlBulkCopy(connectionString);
            foreach (var prop in typeof(TModel).GetProperties())
            {
                bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping
                {
                    SourceColumn = prop.Name,
                    DestinationColumn = prop.Name
                });

                table.Columns.Add(prop.Name);
            }
            entities.ForEach(item =>
            {
                tmpDr = table.NewRow();
                foreach (SqlBulkCopyColumnMapping col in bulk.ColumnMappings)
                {
                    propInfo = type.GetProperty(col.SourceColumn);
                    tmpDr[col.DestinationColumn] = propInfo.GetValue(item);
                }
                table.Rows.Add(tmpDr);
            });
            bulk.BatchSize = 10000;
            bulk.BulkCopyTimeout = 5 * 60;
            bulk.DestinationTableName = "[" + typeof(TModel).Name + "]";
            await bulk.WriteToServerAsync(table);
#else
            throw new NotSupportedException(Resource.ResourceManager.GetString("ERROR_NO_SUPPORT"));
#endif
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="TModel">实体类型</typeparam>
        /// <param name="predicate">实体</param>
        /// <returns></returns>
        public async Task BulkDelete<TModel>(Expression<Func<TModel, bool>> predicate) where TModel : class, IEntity<TModel>, new()
        {
            var set = DbContext.Set<TModel>().AsQueryable();
            set = (predicate == null) ? set : set.Where(predicate);

            string sql = set.ToString().Replace("\r", "").Replace("\n", "").Trim();
            if (predicate == null && !string.IsNullOrEmpty(sql) && !string.IsNullOrWhiteSpace(sql))
                sql += " WHERE 1=1";

            Regex reg = new Regex("^SELECT[\\s]*(?<Fields>.*)[\\s]*FROM[\\s]*(?<Table>.*)[\\s]*AS[\\s]*(?<TableAlias>.*)[\\s]*WHERE[\\s]*(?<Condition>.*)", RegexOptions.IgnoreCase);
            Match match = reg.Match(sql);

            if (!match.Success)
                throw new ArgumentException(Resource.ResourceManager.GetString("ERROR_NOT_SUPPORT_OPERATE"));

            string table = match.Groups["Table"].Value.Trim();
            string tableAlias = match.Groups["TableAlias"].Value.Trim();
            string condition = match.Groups["Condition"].Value.Trim().Replace(tableAlias, table);

            string sql1 = string.Format("DELETE FROM {0} WHERE {1}", table, condition);

            try
            {
                await DbContext.Database.BeginTransactionAsync();
                await DbContext.Database.ExecuteSqlCommandAsync(sql1);
                DbContext.Database.CommitTransaction();
            }
            catch (Exception e)
            {
                DbContext.Database.RollbackTransaction();
                throw e;
            }
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <typeparam name="TModel">实体类型</typeparam>
        /// <param name="entities">实体</param>
        /// <returns></returns>
        public Task BulkUpdate<TModel>(List<TModel> entities) where TModel : class, IEntity<TModel>, new()
        {
            DbContext.Set<TModel>().UpdateRange(entities);
            return Task.FromResult<object>(null);
        }

        public TService Delete<TModel>(TModel entity) where TModel : class, IEntity<TModel>, new()
        {
            try
            {
                DbContext.Remove(entity).State = EntityState.Deleted;
                return this as TService;
            }
            catch (Exception ex)
            {
                DbContext.Attach(entity).State = EntityState.Unchanged;
                throw ex;
            }
        }

        public TService Update<TModel>(TModel entity) where TModel : class, IEntity<TModel>, new()
        {
            try
            {
                DbContext.Update(entity).State = EntityState.Modified;
                return this as TService;
            }
            catch (Exception ex)
            {
                DbContext.Attach(entity).State = EntityState.Unchanged;
                throw ex;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public virtual void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        /// <summary>
        /// 新增并保存
        /// </summary>
        /// <param name="entity"></param>
        public void AddSave<TModel>(TModel entity) where TModel : class, IEntity<TModel>, new()
            => Add(entity).SaveChanges(); 

        /// <summary>
        /// 修改并保存
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateSave<TModel>(TModel entity) where TModel : class, IEntity<TModel>, new()
            => Update(entity).SaveChanges();

        /// <summary>
        /// 删除并保存
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteSave<TModel>(TModel entity) where TModel : class, IEntity<TModel>, new()
            => Delete(entity).SaveChanges();
        
        /// <summary>
        /// 查找记录
        /// </summary>
        /// <typeparam name="TModel">实体类型</typeparam>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        public IEnumerable<TModel> Find<TModel>(Expression<Func<TModel, bool>> predicate) 
            where TModel : class, IEntity<TModel>, new()
        {
            if (predicate == null)
            {
                return DbContext.Set<TModel>().AsQueryable();
            }
            else
            {
                return DbContext.Set<TModel>().Where(predicate).AsQueryable();
            }
        }

        /// <summary>
        /// 查找记录
        /// </summary>
        /// <typeparam name="TModel">实体类型</typeparam>
        /// <param name="predicate">条件</param>
        /// <param name="useReadonlyDb">是否查询从库</param>
        /// <returns></returns>
        public IEnumerable<TModel> Find<TModel>(Expression<Func<TModel, bool>> predicate,
            bool useSlaveDb)
            where TModel : class, IEntity<TModel>, new()
        {
            if (useSlaveDb)
            {
                CreateReadonlyDbContext();
                if (predicate == null)
                {
                    return ReadonlyDbContext.Set<TModel>().AsQueryable();
                }
                else
                {
                    return ReadonlyDbContext.Set<TModel>().Where(predicate).AsQueryable();
                }
            }
            else
            {
                if (predicate == null)
                {
                    return DbContext.Set<TModel>().AsQueryable();
                }
                else
                {
                    return DbContext.Set<TModel>().Where(predicate).AsQueryable();
                }
            }
        }
    }

    /// <summary>
    /// 此类为实体操作基类,不应该被其他类继承
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public class EntityFrameworkRepositoryBase<TService, TModel> :
        EntityFrameworkRepositoryBase<TService>,
        IRepository<TService, TModel>
        where TService : EntityFrameworkRepositoryBase<TService, TModel>
        where TModel : class, IEntity<TModel>, new()
    {
        public EntityFrameworkRepositoryBase(ApplicationDbContext dbContext, ILoggerFactory logger) : base(dbContext)
        { }

        /// <summary>
        /// 新增记录,后面需调用SaveChanges
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public TService Add(TModel entity)
        {
            return base.Add(entity);
        }

        /// <summary>
        /// 修改记录,后面需调用SaveChanges
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public TService Update(TModel entity)
        {
            return base.Update(entity);
        }

        /// <summary>
        /// 删除记录,后面需调用SaveChanges
        /// </summary>
        /// <param name="entity">实体</param>
        public TService Delete(TModel entity)
        {
            return base.Delete(entity);
        }

        /// <summary>
        /// 保存
        /// </summary>
        public override void SaveChanges()
        {
            base.SaveChanges();
        }

        /// <summary>
        /// 新增并保存
        /// </summary>
        /// <param name="entity"></param>
        public void AddSave(TModel entity) => Add(entity).SaveChanges();

        /// <summary>
        /// 修改并保存
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateSave(TModel entity) => Update(entity).SaveChanges();

        /// <summary>
        /// 删除并保存
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteSave(TModel entity) => Delete(entity).SaveChanges();

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task BulkUpdate(List<TModel> entities)
        {
            await base.BulkUpdate(entities);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task BulkDelete(Expression<Func<TModel, bool>> predicate = null)
        {
            await base.BulkDelete(predicate);
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task BulkAdd(List<TModel> entities)
        {
            await base.BulkAdd(entities);
        }

        /// <summary>
        /// 查找记录按条件
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        public IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate = null)
        {
            return base.Find(predicate);
        }

        /// <summary>
        /// 查找记录按条件
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="useSlaveDb">使用从库</param>
        /// <returns></returns>
        public IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate,
           bool useSlaveDb)
        {
            return base.Find(predicate, useSlaveDb);
        }
    }

    #endregion
    
        
    /// <summary>
    /// 实体操作类
    /// </summary>
    public class EntityFrameworkRepository : EntityFrameworkRepositoryBase<EntityFrameworkRepository>
    {
        public EntityFrameworkRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
    
    /// <summary>
    /// 实体操作类
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class EntityFrameworkRepository<TModel> : EntityFrameworkRepositoryBase<EntityFrameworkRepository<TModel>, TModel>
        where TModel : class, IEntity<TModel>, new()
    {
        public EntityFrameworkRepository(ApplicationDbContext dbContext, ILoggerFactory logger) : base(dbContext, logger)
        {

        }
    }
}
