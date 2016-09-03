/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：OperateRightHandler.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-14 17:53:36
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Http.Features.Authentication;
using System;
using System.Threading.Tasks;
using System.Linq;
using NJLFramework.Config;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace NJLFramework.DomainService.Permission
{
    public class OperateRightHandler : RightHandler<RightOption>
    {
        public OperateRightHandler(RightOption options) : base(options) { }

        public override async Task<RightAuthorizeResult> Authorize(RightAuthorizeContext context)
        {
            Guid userId = Guid.Empty;
            string username = "";
            var user = context.HttpContext.User;
            foreach (var identity in user.Identities)
            {
                if (identity.IsAuthenticated && identity.AuthenticationType == Const.AUTHORIZE_TYPE)
                {
                    foreach (var item in identity.Claims)
                    {
                        if (item.Type == Const.AUTHORIZE_NAME_IDENTITY_SCHEME)
                        {
                            Guid.TryParse(item.Value, out userId);
                        }
                        else if (item.Type == Const.AUTHORIZE_NAME_SCHEME)
                        {
                            username = item.Value;
                        }
                    }
                }
            }

            if (userId==Guid.Empty)
            {
                throw new InvalidOperationException(Resources.EXCEPTION_USER_NOT_FOUND);
            }

            var userService = FrameworkConfig.IocConfig.Resolve<UserService>();
            var userInfo =await userService.FindUserById(userId);

            throw new Exception();
        }
    }
}
