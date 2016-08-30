/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：LogMenager.cs
// 文件功能描述：
// 用户日志管理类
// 用于管理用户日志的恢复策略
// 包含日志读取、日志编辑、日志恢复执行三个方面
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
    public class LogService:IDomainService
    {
        EntityFrameworkRepository _entityRep;
        RestoreStrategyService _restoreStrategyService;

        public LogService(EntityFrameworkRepository entityRep, RestoreStrategyService restoreStrategyService)
        {
            _entityRep = entityRep;
            _restoreStrategyService = restoreStrategyService;
        }

        /// <summary>
        /// 日志编写器
        /// </summary>
        /// <returns></returns>
        public void Write(OperateLog operateLog)
        {
            _entityRep.AddSave(operateLog);            
        }

        /// <summary>
        /// 日志编写器
        /// </summary>
        /// <returns></returns>
        public async void Write(List<OperateLog> loglist)
        {
            await _entityRep.BulkAdd(loglist);
        }

        /// <summary>
        /// 日志读取器
        /// </summary>
        /// <returns></returns>
        public List<OperateLog> Read()
        {
            return _entityRep.Find<OperateLog>(null).ToList();
        }

        /// <summary>
        /// 日志恢复器
        /// </summary>
        /// <returns></returns>
        public bool Restore(OperateLog OperateLog)
        {
            return _restoreStrategyService.Perform(OperateLog);            
        }
    }
}
