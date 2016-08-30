/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RightAuthentication.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-13 17:30:29
//----------------------------------------------------------------*/



using NJLFramework.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// 权限验证类
    /// </summary>
    public class RightAuthorize
    {
        public RightAuthorize()
        {
            Handlers = new List<RightHandler<RightOption>>();
        }
        public void RegisterHandler(RightHandler<RightOption> handler)
        {
            Handlers.Add(handler);
        }

        public List<RightHandler<RightOption>> Handlers { get; private set; }

        public async Task<bool> AuthorizeAsync(RightAuthorizeContext context)
        {
            if (string.IsNullOrWhiteSpace(context.ModuleKey))
                throw new ArgumentNullException(nameof(context.ModuleKey));

            if (string.IsNullOrWhiteSpace(context.Operate))
                throw new ArgumentNullException(nameof(context.Operate));


            RightAuthorizeResult result = null;
            foreach (var handler in Handlers.OrderBy(p=>p.Option.Order))
            {
                result = await handler.AuthorizeAsync(context);
                if (result.Failed != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
