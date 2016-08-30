﻿/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：UserManagerExtension.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-17 10:45:37
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using NJLFramework.Base;
using NJLFramework.Database;
using NJLFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// 用户管理 
    /// </summary>
    public class UserService : UserManager<User>, IDomainService
    {
        private ApplicationUserStore _store;
        public UserService(ApplicationUserStore store,
            Microsoft.Extensions.Options.IOptions<IdentityOptions> optionAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidator,
            IEnumerable<IPasswordValidator<User>> passwordValidator,
            ILookupNormalizer normalizer,
            IdentityErrorDescriber errorDescriber,
            IServiceProvider serviceProvider,
            ILogger<UserService> logger)
            :base(store, optionAccessor, passwordHasher, 
                 userValidator, passwordValidator,normalizer, 
                 errorDescriber, serviceProvider,logger)
        {
            Options = optionAccessor?.Value??new IdentityOptions();
            PasswordHasher = passwordHasher;

            _store = store;
        }

        public IPasswordHasher<User> PasswordHasher { get;private set; }

        public IdentityOptions Options { get; private set; }

        private static TService GetService<TService>(HttpContext context) where TService:class
        {
            if(context==null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.RequestServices.GetService<TService>();
        }

        /// <summary>
        /// 查找用户通过UserToken
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        /// <example>
        /// 
        /// </example>
        public Task<User> FindByUserToken(string clientId)
        {
            if(string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }
            
            var user = _store.Users.Where(p => p.UserToken == clientId).FirstOrDefault();
            return Task.FromResult(user);
        }

        /// <summary>
        /// 通过UserId查询用户
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="queryCache">是否使用缓存</param>
        /// <returns></returns>
        public Task<User> FindUserById(string userId, bool queryCache = true)
        {
            //queryCache is true   to do:

            var user = _store.Users.Where(p => p.Id == userId).FirstOrDefault();
            return Task.FromResult(user);
        }
    }
}