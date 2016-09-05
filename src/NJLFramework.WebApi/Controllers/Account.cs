/*----------------------------------------------------------------
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
using System;
using System.Threading.Tasks;
using System.Linq;
using NJLFramework.Model.Permission.ViewModels;

namespace NJLFramework.WebApi.Controllers
{
    [Route("[controller]")]
    public class AccountController: Controller
    {
        private AccountService _accountService;
        private ILogger _logger;

        public AccountController(AccountService accountService,
            ILoggerFactory loger)
        {
            _accountService = accountService;
            _logger = loger.CreateLogger(nameof(AccountController));
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
                try
                {
                    IdentityResult result=await _accountService.Register(model);
                    if (!result.Succeeded)
                    {
                        return GetErrorResult(result);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException == null)
                    {
                        ModelState.AddModelError("Register", ex.Message);
                    }
                    else
                    {
                        ModelState.AddModelError("Register", ex.InnerException.Message);
                    }

                    return ErrorApiResult.FromModelState(ModelState);
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
