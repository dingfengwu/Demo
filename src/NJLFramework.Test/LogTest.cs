using NJLFramework.Config;
using NJLFramework.Database;
using NJLFramework.Model;
using NJLFramework.UserLog;
using System;
using Xunit;

namespace NJLFramework.Test
{
    public class LogTest
    {
        [Fact]
        public void AddLog()
        {
            var entityRep = FrameworkConfig.IocConfig.Resolve<EntityFrameworkRepository>();
            var restStraSvr = FrameworkConfig.IocConfig.Resolve<RestoreStrategyService>();
            LogService lm = new LogService(entityRep, restStraSvr);
            var m = new OperateLog()
            {
                id = 10,
                account = "zhanghao123456",
                app = "frametest",
                browser = "no",
                ipAddress = "10.0.1.12",
                module = "logtest",
                userId = "asdasdasdadasdad",
                influence = "",
                oprTime = DateTime.Now,
                operation = "add log test",
                isRecovery = true,
                isRecoveryed = false,
                oprType = "json",
                userName = "wzj",
                result = "adadddd",
                state = 1
            };
            var ss = new { name = "zhangsan", age = 23 };
            var cc = new { name = "lisi", age = 33 };
            m.SetOprData("tt", "ff", "aa", ss, cc);
            lm.Write(m);
        }

        
    }
}
