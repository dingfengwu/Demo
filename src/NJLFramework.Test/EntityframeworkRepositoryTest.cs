/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：EntityframeworkRepositoryTest.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-12 19:27:57
//----------------------------------------------------------------*/



using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NJLFramework.Base;
using NJLFramework.Config;
using NJLFramework.Database;
using NJLFramework.Model;
using NJLFramework.Model.Permission;
using System;
using System.Collections.Generic;
using Xunit;

namespace NJLFramework.Test
{
    public class EntityframeworkRepositoryTest
    {
        #pragma warning disable 1998
        /// <summary>
        /// 测试批量插入
        /// </summary>
        [Fact]
        public async void TestBlukInsert()
        {
            var testHelper = new TestHelper();
            testHelper.CreateServer();
            var loggerFactory = testHelper.Builder.ApplicationServices.GetService<ILoggerFactory>();
            using (ApplicationDbContext context = FrameworkConfig.IocConfig.Resolve<ApplicationDbContext>())
            {
                var entities = new List<Departments>();
                var idGenerator = FrameworkConfig.IocConfig.Resolve<IdGenerator>();
                EntityFrameworkRepository<Departments> rep = new EntityFrameworkRepository<Departments>(context, loggerFactory);

                for (var i = 0; i < 1000000; i++)
                {
                    entities.Add(new Departments
                    {
                        Id = idGenerator.GetId(),
                        DepartmentType = 1,
                        Name = "Dpt" + i.ToString(),
                        ParentId = Guid.Empty
                    });
                }

#if DNX451 || NET451
                await rep.BulkAdd(entities);
#else
                throw new NotSupportedException("this runtime not support");
#endif
            }
        }
        
    }
}
