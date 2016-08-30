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

namespace NJLFramework.Database
{
    public partial class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        /// <summary>
        /// 操作
        /// </summary>
        public DbSet<Activity> Activities { get; set; }
        
        /// <summary>
        /// 列
        /// </summary>
        public DbSet<Column> Columns { get; set; }

        /// <summary>
        /// 列权限
        /// </summary>
        public DbSet<ColumnPermission> ColumnPermissions { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// 部门范围权限
        /// </summary>
        public DbSet<DepartmentPermission> DepartmentPermissions { get; set; }

        /// <summary>
        /// 员工
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public DbSet<Menu> Menus { get; set; }

        /// <summary>
        /// 菜单权限
        /// </summary>
        public DbSet<MenuPermission> MenuPermissions { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public DbSet<Position> Positions { get; set; }

        /// <summary>
        /// 资源
        /// </summary>
        public DbSet<Resource> Resources { get; set; }

        /// <summary>
        /// 资源
        /// </summary>
        public DbSet<ResourcePermission> ResourcePermissions { get; set; }

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
