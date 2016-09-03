/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RoleManagerExtension.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-17 10:47:02
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using NJLFramework.Base;
using NJLFramework.Model;
using NJLFramework.Model.Permission;
using System.Collections.Generic;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleService:RoleManager<Roles>, IDomainService
    {
        public RoleService(ApplicationRoleStore store,
            IEnumerable<IRoleValidator<Roles>> validator,
            ILookupNormalizer normalizer,
            IdentityErrorDescriber errorDescriber,
            ILogger<RoleService> logger,
            IHttpContextAccessor accessor
            )
            :base(store,validator, normalizer, errorDescriber,logger, accessor)
        {

        }
    }
}
