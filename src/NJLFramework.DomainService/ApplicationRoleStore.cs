using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NJLFramework.Model;
using NJLFramework.Model.Permission;
using System;

namespace NJLFramework.DomainService.Permission
{
    public class ApplicationRoleStore : RoleStore<Roles, DbContext, Guid>, IRoleStore<Roles>
    {
        public ApplicationRoleStore(DbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}