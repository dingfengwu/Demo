using NJLFramework.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NJLFramework.Model.Permission;
using System;

namespace NJLFramework.Database
{
    public partial class ApplicationDbContext : IdentityDbContext<Users,Roles,Guid>
    {
        /// <summary>
        /// 用户操作日志恢复策略
        /// </summary>
        public DbSet<LogRecoveryStrategy> LogRecoveryStrategys { get; set; }
        
    }
}
