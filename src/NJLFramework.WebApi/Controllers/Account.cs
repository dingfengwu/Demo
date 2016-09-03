﻿/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Account.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-14 11:44:22
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NJLFramework.Base;
using NJLFramework.DomainService.Permission;
using NJLFramework.Model.Permission;
using System.Threading.Tasks;


namespace NJLFramework.WebApi.Controllers
{
    [Route("[controller]")]
    public class AccountController: Controller
    {
        private PermissionService _service;
        private UserService _userService;
        private ILogger _logger;
        private SignInManager<Users> _signInManager;

        public AccountController(PermissionService service,UserService userService, 
            ILoggerFactory loger, SignInManager<Users> signInManager)
        {
            _service = service;
            _userService = userService;
            _logger = loger.CreateLogger(nameof(AccountController));
            _signInManager = signInManager;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<ApiResult> Register([FromForm] UserViewModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return ErrorApiResult.FromModelState(ModelState);
            }
            else
            {
                var user = new Users() { UserName = model.UserName, Email = model.Password };
                IdentityResult result = await _userService.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
            }
            return this.Good();
        }

        private ApiResult GetErrorResult(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return ErrorApiResult.FromModelState(ModelState);
        }
        
    }
}
