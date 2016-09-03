/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Authorize.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-25 16:50:34
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using NJLFramework.Config;
using NJLFramework.DomainService.Permission;
using NJLFramework.WebApi.ViewModel.ApiAuthorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJLFramework.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api")]
    public class ApiAuthorizeController:Controller
    {
        private ILogger _logger;
        private UserService _userService;
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;
        private IStringLocalizer _localizer;
        
        public ApiAuthorizeController(UserService userService,
            ILoggerFactory loger, 
            IHostingEnvironment env, 
            IConfigurationRoot config,
            IStringLocalizer<ApiAuthorizeController> controllerLocalizer)
        {
            _logger = loger.CreateLogger(nameof(AccountController));
            _userService = userService;
            _env = env;
            _config = config;
            _localizer = controllerLocalizer;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string redirect_uri)
        {
            ViewData["Redirect_Url"] = redirect_uri;
            return View("Login");
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model, string redirect_uri)
        {
            ViewData["Redirect_Url"] = redirect_uri;
            if (ModelState.IsValid)
            {
                var user=await _userService.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, _localizer["ERROR_USER_NO_FOUND"]);
                    return View("Login");
                }
                if (!await _userService.CheckPasswordAsync(user, model.Password))
                {
                    ModelState.AddModelError(string.Empty, _localizer["ERROR_USER_PASSWORD_NOT_FOUND"]);
                    return View("Login");
                }

                //_logger.LogInformation(new EventId(0x0001,"User Login"), "User logged in.");

                return RedirectToReturnUrl(redirect_uri);
            }

            return View("Login");
        }



        /// <summary>
        /// 判断跳转地址是否有效，并执行跳转
        /// </summary>
        /// <param name="redirect_uri">跳转地址</param>
        /// <returns></returns>
        private IActionResult RedirectToReturnUrl(string redirect_uri)
        {
            var allowRedirectList = new List<string>();
            FrameworkConfig.Settings.GetSection("RedirectUrlList").Bind(allowRedirectList);

            if (allowRedirectList.Any(p => p.ToLower() == redirect_uri.ToLower()))
            {
                return Redirect(redirect_uri);
            }
            else
            {
                var errorRedirectUrl = FrameworkConfig.Settings["AuthorizeErrorRedirectUrl"];
                return Redirect(errorRedirectUrl);
            }
        }



        /// <summary>
        /// 设置语言
        /// </summary>
        /// <param name="culture">语言</param>
        /// <returns></returns>
        [HttpGet]
        [Route("SetLanguage")]
        [AllowAnonymous]
        public IActionResult SetLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            var returnUrl = "/ApiAuthorize";
            return LocalRedirect(returnUrl);
        }
    }
}
