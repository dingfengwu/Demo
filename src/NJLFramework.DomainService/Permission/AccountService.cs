using Microsoft.AspNetCore.Identity;
using NJLFramework.Database;
using NJLFramework.Model.Permission;
using NJLFramework.Model.Permission.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJLFramework.DomainService.Permission
{
    public class AccountService
    {
        EntityFrameworkRepository _entityRep;
        UserService _userService;

        public AccountService(EntityFrameworkRepository entityRep,
            UserService userService
            )
        {
            _entityRep = entityRep;
            _userService = userService;

        }

        public async Task<IdentityResult> Register(UserViewModel model)
        {
#if DEBUG
            var firstCompanyId = _entityRep.Find<SysCompany>(null).First().Id;
            var firstEmployeeId = _entityRep.Find<Employees>(null).First().Id;
            var firstUserId = _entityRep.Find<Users>(null).First().Id;

            var user = new Users() {
                UserName = model.UserName,
                Email = model.UserName,
                CompanyId=firstCompanyId,
                EmployeeId=firstEmployeeId,
                CreateTime=DateTime.Now,
                CreateUserId=firstUserId
            };
            user.EmployeeId = Guid.Parse("340B6B3F-4773-E611-ABDD-4437E6D3DE47");
            IdentityResult result = await _userService.CreateAsync(user, model.Password);

            return result;
#endif
        }
    }
}
