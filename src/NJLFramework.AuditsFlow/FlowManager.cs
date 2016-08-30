/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：FlowManager.cs
// 文件功能描述：
// 审核流管理器
//
// 创建人  ：WZJ
// 创建日期：2016-04-23 11:50:00
//----------------------------------------------------------------*/

using NJLFramework.Config;
using NJLFramework.Database;
using NJLFramework.Model;
using System.Collections.Generic;
using System.Linq;

namespace NJLFramework.AuditsFlow
{
    public class FlowManager
    {
        EntityFrameworkRepository _entityRep;

        public FlowManager(EntityFrameworkRepository entityRep)
        {
            _entityRep = entityRep;
        }

        #region 审核流

        public List<AuditFlow> GetAuditFlow()
        {
            return _entityRep.Find<AuditFlow>(null).ToList();
        }

        public void AddAuditFlow(AuditFlow model)
        {
            _entityRep.AddSave(model);
        }

        public async void AddAuditFlow(List<AuditFlow> list)
        {
            await _entityRep.BulkAdd(list);
        }

        #endregion

        #region 审核策略

        public List<AuditStrategy> GetAuditStrategy()
        {
            return _entityRep.Find<AuditStrategy>(null).ToList();
        }

        public void AddAuditStrategy(AuditStrategy model)
        {
            _entityRep.AddSave(model);
        }

        public async void AddAuditStrategy(List<AuditStrategy> list)
        {
            await _entityRep.BulkAdd(list);
        }

        #endregion
        
        #region 审核流操作记录

        public List<FlowOperation> GetFlowOperation()
        {
            return _entityRep.Find<FlowOperation>(null).ToList();
        }

        public void AddFlowOperation(FlowOperation model)
        {
            _entityRep.AddSave(model);
        }

        public async void AddFlowOperation(List<FlowOperation> list)
        {
            await _entityRep.BulkAdd(list);
        }

        #endregion

    }
}

 
 