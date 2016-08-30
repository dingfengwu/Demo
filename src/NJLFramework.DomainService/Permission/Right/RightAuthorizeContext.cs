/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RightAuthorizeContext.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-14 11:57:09
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Collections.Generic;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// 权限验证上下文
    /// </summary>
    public class RightAuthorizeContext:ActionContext
    {
        private ActionContext context;
        private string module;
        private IList<ParameterDescriptor> parameters;

        public RightAuthorizeContext(ActionContext context, string module, string operate, IList<ParameterDescriptor> parameters)
        {
            this.context = context;
            this.module = module;
            Operate = operate;
            this.parameters = parameters;
        }
        
        /// <summary>
        /// 模块Key
        /// </summary>
        public string ModuleKey { get; private set; }

        /// <summary>
        /// 操作key
        /// </summary>
        public string Operate { get; private set; }

        /// <summary>
        /// 模块所对应实体的Id
        /// </summary>
        public IList<ParameterDescriptor> Parameters { get; private set; }
    }
}
