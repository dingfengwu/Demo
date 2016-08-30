/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：SecurityMiddlewareExtension.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-28 16:41:31
//----------------------------------------------------------------*/




using Microsoft.AspNetCore.Builder;

namespace NJLFramework.Middleware
{
    public static class SecurityMiddlewareExtension
    {
        public static IApplicationBuilder UseSecurity(this IApplicationBuilder app,SecurityMiddlewareOption options)
        {
            return app.UseMiddleware<SecurityMiddleware>(options);
        }
    }
}
