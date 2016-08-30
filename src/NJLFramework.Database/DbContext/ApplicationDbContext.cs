using NJLFramework.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NJLFramework.Database
{
    public partial class ApplicationDbContext : IdentityDbContext<User,Role,string>
    {
        public ApplicationDbContext() : base()
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //调用父类方法
            base.OnModelCreating(builder);

        }
        
    }
}
