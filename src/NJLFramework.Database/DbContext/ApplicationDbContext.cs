using NJLFramework.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NJLFramework.Model.Permission;
using System;

namespace NJLFramework.Database
{
    public partial class ApplicationDbContext : IdentityDbContext<Users,Roles,Guid>
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
