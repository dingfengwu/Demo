/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：SqlTxtReadTest.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-23 10:24:58
//----------------------------------------------------------------*/



using Microsoft.Extensions.DependencyInjection;
using NJLFramework.Config;
using NJLFramework.DomainService.Permission;
using NJLFramework.WebApi;
using Xunit;

namespace NJLFramework.Test
{
    /// <summary>
    /// SQL语句读取测试
    /// </summary>
    public class SqlTxtReadTest
    {
        #pragma warning disable 1998
        [Fact]
        public async void Read()
        {
            var services = new ServiceCollection();
            var start = new Startup();
            start.ConfigEnvironment();
            start.ConfigServices(services);

            DepartmentService dpt = FrameworkConfig.IocConfig.Resolve<DepartmentService>();

#if DNX451 || NET451
            var mgr = new DbConfigureManager();

            var sql = dpt.GetResource();
            Assert.True(sql != null);

            sql = dpt.GetResource1();
            Assert.True(sql != null);

            sql = await mgr.Read("key1", 
                Kehu1688.Framework.Permission.Service.Resources.ResourceManager);
            Assert.True(sql != null);
            
            sql = await mgr.Read("key2", 
                Kehu1688.Framework.Permission.Service.Resources.ResourceManager);
            Assert.True(sql != null);

            sql = await mgr.Read("key3", 
                Kehu1688.Framework.Permission.Service.Resources.ResourceManager);
            Assert.True(sql == null);
#endif
        }
    }
}
