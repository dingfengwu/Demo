/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RecoveryStrategyManager.cs
// 文件功能描述：
// 用户日志恢复策略管理类
// 用于管理用户日志的恢复策略
// 包含策略的读取、策略的编辑、策略的执行三个方面
//
// 创建人  ：WZJ
// 创建日期：2016-04-23 10:40:00
//----------------------------------------------------------------*/

using NJLFramework.Base;
using NJLFramework.Database;
using NJLFramework.Model;
using System.Collections.Generic;
using System.Linq;

namespace NJLFramework.UserLog
{
    public class RestoreStrategyService :IDomainService
    {
        EntityFrameworkRepository _entityRep;

        public RestoreStrategyService (EntityFrameworkRepository entityRep)
        {
            _entityRep = entityRep;
        }

        /// <summary>
        /// 恢复策略执行
        /// </summary>
        public bool Perform(OperateLog model)
        {            
            return false;
        }

        /// <summary>
        /// 恢复策略读取
        /// </summary>
        public List<LogRecoveryStrategy> Read()
        {
            return _entityRep.Find<LogRecoveryStrategy>(null).ToList();
        }

        /// <summary>
        /// 恢复策略编写
        /// </summary>
        public void Write(LogRecoveryStrategy model)
        {
            _entityRep.AddSave(model);
        }

        /// <summary>
        /// 恢复策略编写器
        /// </summary>
        public async void Write(List<LogRecoveryStrategy> recoverylist)
        {
            await _entityRep.BulkAdd(recoverylist);
        }
    }
}
