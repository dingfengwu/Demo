/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：PermissionDomainService.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-11 21:19:19
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using NJLFramework.Base;
using NJLFramework.Config;
using NJLFramework.Database;
using NJLFramework.Model;
using NJLFramework.Model.Permission;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// 授权管理
    /// </summary>
    public class PermissionService:IDomainService
    {
        EntityFrameworkRepository _rep;
        DepartmentService _dptService;

        public PermissionService(EntityFrameworkRepository rep, 
            DepartmentService departmentService)
        {
            _rep = rep;
            _dptService = departmentService;
        }

        /// <summary>
        /// 验证权限,
        /// 每个Action都必须加上PermissionAuthroize的描述,
        /// 且必须为Operate,Module给值,
        /// 然后如果参数中存在ViewModel，则取Id作为数据权限验证的唯一标识
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual async Task<bool> Authorize(ActionContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var attributes = descriptor.MethodInfo.CustomAttributes;
            var permissionAuthorize = attributes.Where(p => p.AttributeType == typeof(PermissionAuthroizeAttribute)).FirstOrDefault();
            if (permissionAuthorize != null)
            {
                var operate = "";
                var module = "";
                foreach (var arg in permissionAuthorize.NamedArguments)
                {
                    if (arg.MemberName == nameof(PermissionAuthroizeAttribute.Operate))
                    {
                        operate = arg.TypedValue.Value.ToString();
                    }
                    else if (arg.MemberName == nameof(PermissionAuthroizeAttribute.Module))
                    {
                        module = arg.TypedValue.Value.ToString();
                    }
                }
                var parameters = descriptor.Parameters;

                var rightContext = new RightAuthorizeContext(context, module, operate, parameters);
                return await FrameworkConfig.IocConfig.Resolve<RightAuthorize>().AuthorizeAsync(rightContext);
            }

            return true;
        }

        /// <summary>
        /// 查询用户授权
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public Task<List<ModulePermission>> QueryUserPermission(string userId,string resourceId)
        {
            throw new System.Exception("not impletement");
        }
    }
}
