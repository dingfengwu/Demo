using NJLFramework.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NJLFramework.Database
{
    public partial class ApplicationDbContext : IdentityDbContext<User,Role,string>
    {
        /// <summary>
        /// 用户操作日志恢复策略
        /// </summary>
        public DbSet<LogRecoveryStrategy> LogRecoveryStrategys { get; set; }
        
    }
}
