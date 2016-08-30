/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：DepartmentService.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-12 16:58:34
//----------------------------------------------------------------*/



using Microsoft.Extensions.Logging;
using NJLFramework.Base;
using NJLFramework.Database;
using NJLFramework.Model;
using System;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace NJLFramework.DomainService.Permission
{
    public class DepartmentService: IDomainService
    {
        EntityFrameworkRepository<Department> _entityRep;
        ILogger _logger;

        public DepartmentService(EntityFrameworkRepository<Department> entityRep,ILoggerFactory logger)
        {
            _entityRep = entityRep;
            _logger = logger.CreateLogger(nameof(DomainService));
        }

        public string GetResource()
        {
            return Resources.mssqlserver;
        }

        /// <summary>
        /// 增加部门
        /// </summary>
        /// <param name="dpt"></param>
        public void Add(Department dpt)
        {
            _entityRep.Add(dpt).SaveChanges();
        }

        /// <summary>
        /// 查找部门
        /// </summary>
        public List<Department> Find(Expression<Func<Department, bool>> predicate = null)
        {
            return _entityRep.Find<Department>(predicate).ToList();
        }

        /// <summary>
        /// 查找部门
        /// </summary>
        public List<Department> Find(Expression<Func<Department, bool>> predicate,bool useSlaveDb)
        {
            return _entityRep.Find<Department>(predicate,useSlaveDb).ToList();
        }
    }
}
