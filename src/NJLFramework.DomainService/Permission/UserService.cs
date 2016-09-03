/*----------------------------------------------------------------
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



using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NJLFramework.Base;
using NJLFramework.Database;
using NJLFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NJLFramework.Model.Permission;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// 用户管理 
    /// </summary>
    public class UserService : UserManager<Users>, IDomainService
    {
        private ApplicationUserStore _store;
        public UserService(ApplicationUserStore store,
            Microsoft.Extensions.Options.IOptions<IdentityOptions> optionAccessor,
            IPasswordHasher<Users> passwordHasher,
            IEnumerable<IUserValidator<Users>> userValidator,
            IEnumerable<IPasswordValidator<Users>> passwordValidator,
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

        public IPasswordHasher<Users> PasswordHasher { get;private set; }

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
        public Task<Users> FindByUserToken(string clientId)
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
        public Task<Users> FindUserById(Guid userId, bool queryCache = true)
        {
            //queryCache is true   
            //to do:

            var user = _store.Users.Where(p => p.Id == userId).FirstOrDefault();
            return Task.FromResult(user);
        }
    }
}
