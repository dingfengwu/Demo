/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Permission.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-08-27 12:01:29
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NJLFramework.Model;
using NJLFramework.Model.Permission;
using System;

namespace NJLFramework.Database
{
    public partial class ApplicationDbContext : IdentityDbContext<Users, Roles, Guid>
    {
        /// <summary>
        /// 用户操作日志
        /// </summary>
        public DbSet<OperateLog> UserLogs { get; set; }

        /// <summary>
        /// 表与视图
        /// </summary>
        //public DbSet<TableView> TableViews { get; set; }
    }
}
