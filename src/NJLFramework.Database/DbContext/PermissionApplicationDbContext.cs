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
        partial void InnerOnModelCreating(ModelBuilder builder)
        {
            //调用父类方法
            base.OnModelCreating(builder);

            builder.Entity<Users>().ToTable("Users");
            builder.Entity<Roles>().ToTable("Roles");
            //builder.Entity<Users>().ToTable("Users");
            //builder.Entity<Users>().ToTable("Users");
            //builder.Entity<Users>().ToTable("Users");
            //builder.Entity<Users>().ToTable("Users");
            //builder.Entity<Users>().ToTable("Users");
            //builder.Entity<Users>().ToTable("Users");
        }

        /// <summary>
        /// 用户操作日志
        /// </summary>
        public DbSet<OperateLog> UserLogs { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public new DbSet<Users> Users { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public new DbSet<Users> Roles { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public DbSet<SysCompany> SysCompany { get; set; }

        /// <summary>
        /// 员工
        /// </summary>
        public DbSet<Employees> Employees { get; set; }
        

    }
}
