/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：ReadWriteSplitTest.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-19 15:09:16
//----------------------------------------------------------------*/



using Microsoft.Extensions.Logging;
using NJLFramework.Base;
using NJLFramework.Config;
using NJLFramework.DomainService.Permission;
using NJLFramework.Model;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace NJLFramework.Test
{
    /// <summary>
    /// 读写分离测试
    /// </summary>
    public class ReadWriteSplitTest
    {
        /// <summary>
        /// 测试读写分离
        /// </summary>
        [Fact]
        public void TestReadWriteSplit()
        {
            var helper = new TestHelper();
            var server = helper.CreateServer();
            var dptSvr = FrameworkConfig.IocConfig.Resolve<DepartmentService>();
            var logger = FrameworkConfig.IocConfig.Resolve<ILoggerFactory>().CreateLogger(nameof(TestReadWriteSplit));
            var id = IdGenerator.Instance.GuidToLongId().ToString();
            dptSvr.Add(new Department
            {
                DepartmentType = 0,
                Id = id,
                Name = "Test8",
                ParentId = "0"
            });

            Stopwatch stop = new Stopwatch();
            stop.Start();
            Department dpt = null;
            do
            {
                dpt = dptSvr.Find(p => p.Id == id, useSlaveDb: true).FirstOrDefault();
            } while (dpt == null);
            stop.Stop();
            
            logger.LogDebug($"the time is {stop.ElapsedMilliseconds}ms");
            Assert.True(dpt != null);
        }
    }
}
