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
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using NJLFramework.DomainService.Permission;
using System.Resources;
using System.Threading.Tasks;
using NJLFramework.Localization.Extension;
using NJLFramework.WebApi.ViewModel.ApiAuthorize;
using System.Linq;
using System.Reflection;
using System.Globalization;

namespace NJLFramework.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
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
            IStringLocalizerFactory stringLocalizerFactory,
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
        public IActionResult Get(string redirect_uri = null)
        {
            ViewData["Redirect_Url"] = redirect_uri;
            ViewData["Login_Header"] = _localizer["LOGIN_HEADER"];
            return View("Login");
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromForm]LoginViewModel model, string redirect_uri = null)
        {
            ViewData["Redirect_Url"] = redirect_uri;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var user = await _userService.FindByNameAsync(model.UserName);
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

                _logger.LogInformation(1, "User logged in.");
                return RedirectToReturnUrl(redirect_uri);
            }

            // If we got this far, something failed, redisplay form
            return View("Login");
        }

        private IActionResult RedirectToReturnUrl(string redirect_uri)
        {
            if (string.IsNullOrWhiteSpace(redirect_uri))
            {
                return Redirect(_config["Host"]);
            }
            else
            {
                var queryParams = Request.QueryString.Value + "&inner=1";
                var url = $"{_config["Host"]}/Authorize{queryParams}";
                return Redirect(url);
            }
        }
    }
}
