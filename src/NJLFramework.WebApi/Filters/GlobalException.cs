/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：GlobalException.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-12 10:38:04
//----------------------------------------------------------------*/




using Microsoft.AspNetCore.Mvc.Filters;
using NJLFramework.Base;

namespace NJLFramework.WebApi
{
    public class GlobalException : IExceptionFilter
    {
        public async void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 400;
            ErrorApiResult result = new ErrorApiResult();
            result.ErrorMsg = context.Exception.Message;
            result.ErrorCode = InnerErrorCode.GLOBAL_EXCEPTION;

            await result.ExecuteResultAsync(context);
        }
    }
}
