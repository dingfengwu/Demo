/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：ApplicationRoleStore.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-18 11:53:53
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NJLFramework.Model;
using NJLFramework.Model.Permission;
using System;

namespace NJLFramework.Database
{
    /// <summary>
    /// 角色存储
    /// </summary>
    internal class ApplicationRoleStore: RoleStore<Roles, ApplicationDbContext, Guid>
    {
        public ApplicationRoleStore(ApplicationDbContext context,IdentityErrorDescriber describer) 
            :base(context,describer)
        {

        }
    }
}
