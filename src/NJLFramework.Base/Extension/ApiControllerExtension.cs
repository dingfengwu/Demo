/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：OK.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-23 19:47:39
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJLFramework.Base
{
    public static class ApiControllerExtension
    {
        public static ApiResult Good(this Controller controler)
        {
            return new ApiResult() { Result = true };
        }
    }
}
