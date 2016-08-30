/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：TestController.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-16 9:39:15
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NJLFramework.Base;
using NJLFramework.Database;
using NJLFramework.DomainService.Permission;
using System.Text;
using System.Threading.Tasks;

namespace NJLFramework.WebApi.Controllers
{
    [Route("[controller]")]
    public class TestController: Controller
    {
        #pragma warning disable 1998
        [HttpPost("Test")]
        [PermissionAuthroize(Module = "Customer", Operate = "Edit")]
        public async Task<ApiResult> Test()
        {
            return new ApiResult
            {
                Data = HttpContext.RequestServices.GetService(typeof(ApplicationDbContext)).GetHashCode(),
                Result = true
            };
        }

        [HttpGet("LongTest")]
        [AllowAnonymous]
        public async Task<string> LongTest()
        {
            HttpContext.Session.Set("Id", Encoding.UTF8.GetBytes("1"));
            
            return HttpContext.TraceIdentifier;
        }

        [HttpGet("ShortTest")]
        [AllowAnonymous]
        public async Task<string> ShortTest()
        {
            HttpContext.Session.Set("Id1", Encoding.UTF8.GetBytes("1"));
            
            return HttpContext.TraceIdentifier;
        }
    }
}
