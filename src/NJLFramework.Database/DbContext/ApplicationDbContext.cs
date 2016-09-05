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
            //不检测更改，加快EF的读取速度
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            //不进行跟踪，加快EF的读取速度,
            //但在修改时，必须手工指定修改状态,
            //如:DbContext.Update(entity).State = EntityState.Modified;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //调用父类方法
            base.OnModelCreating(builder);

            InnerOnModelCreating(builder);
        }

        //分部方法的申明
        partial void InnerOnModelCreating(ModelBuilder builder);
    }
}
