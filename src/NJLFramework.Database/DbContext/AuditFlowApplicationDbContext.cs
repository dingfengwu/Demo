/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：AuditFlowDbContext.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-08-29 9:24:30
//----------------------------------------------------------------*/



using Microsoft.EntityFrameworkCore;
using NJLFramework.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using NJLFramework.Model.Permission;

namespace NJLFramework.Database
{
    public partial class ApplicationDbContext : IdentityDbContext<Users, Roles, Guid>
    {
        /// <summary>
        /// 审核流
        /// </summary>
        public DbSet<AuditFlow> AuditFlows { get; set; }

        /// <summary>
        /// 审核流策略
        /// </summary>
        public DbSet<AuditStrategy> AuditStrategys { get; set; }
    }
}
