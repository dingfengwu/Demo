using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NJLFramework.Model;

namespace NJLFramework.DomainService.Permission
{
    public class ApplicationRoleStore : RoleStore<Role>, IRoleStore<Role>
    {
        public ApplicationRoleStore(DbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}