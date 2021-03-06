﻿/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Class.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-09 10:55:23
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJLFramework.Base
{
    /// <summary>
    /// API返回结果
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class ApiResult<TModel>
    {
        /// <summary>
        /// 调用API的结果
        /// </summary>
        public bool Result { get; set; } = true;

        /// <summary>
        /// 成功调用API后返回的数据
        /// </summary>
        public TModel Data { get; set; }
    }
}
