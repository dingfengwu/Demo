/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Start`.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-22 15:29:45
//----------------------------------------------------------------*/



using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NJLFramework.Database;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NJLFramework.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NJLFramework.DomainService.Permission;
using Microsoft.AspNetCore.Http;
using NJLFramework.Base;
using NJLFramework.Config;
using System.IO;
using NJLFramework.Middleware;
using NJLFramework.Model.Permission;

namespace NJLFramework.WebApi
{
    public partial class Startup
    {
        public Startup()
        {
        }

        /// <summary>
        /// 环境与读取全局配置文件
        /// </summary>
        public void ConfigEnvironment()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IServiceProvider ConfigServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(options => 
                    options.UseSqlServer(Configuration["Data:Connections:WriteConnectionString"])
                );

            //标识身份验证
            services.AddIdentity<Users, IdentityRole>(options => {
                options.Cookies.ApplicationCookie.AuthenticationScheme = "ApplicationCookie";
                //options.Cookies.ApplicationCookie.DataProtectionProvider = new DataProtectionProvider(new DirectoryInfo("C:\\Github\\Identity\\artifacts"));
                options.Cookies.ApplicationCookie.CookieName = "Interop";

                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

                options.User.AllowedUserNameCharacters = null;
                // "abcdefghijklmnopqrstuvwxyz0123456789";
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddPermission();
            services.AddRepositories();

            services.AddMvc(options =>
            {
                options.Filters.Add(PermissionAuthorizeFilter<PermissionRequirement>.Default);

                //options.Filters.Add(typeof(GlobalException), 100);
            });
            services.AddCors();

            //services.AddCaching();
            //services.AddSession();

            //增加注入
            services.AddSingleton(typeof(IConfigurationRoot), Configuration);
            Register.RegisterService(services);
            return Register.Get<IServiceProvider>();
        }

        public void ConfigSetting(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            PublicClientId = "self";
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            loggerFactory.AddProvider(new TextLoggerProvider(options => {
                options.LoggerPath =Path.Combine(env.ContentRootPath,"Logs/");
            }));

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseSecurity(new SecurityMiddlewareOption()
                {
                    AllowArgumentEncrypt = true,
                    ValidateData = true,
                    AppId = PublicClientId
                });


                //数据库牵移
                //try
                //{
                //    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                //        .CreateScope())
                //    {
                //        serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                //             .Database.Migrate();
                //    }
                //}
                //catch { }
            }

            //app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseRightHandler(new List<RightHandler<RightOption>>
            {
               new OperateRightHandler(new RightOption { Order=0, Scheme="Automic" })
            });
            //app.UseSession();


            //使用OAuth服务
            app.UseOAuthBearerTokens(options =>
            {
                options.TokenEndpointPath = new PathString("/Token");
                options.AuthorizeEndpointPath = new PathString("/Authorize");
                options.AccessTokenExpireTimeSpan = TimeSpan.FromDays(1);
                options.AuthorizationCodeExpireTimeSpan = TimeSpan.FromDays(30);

                options.Provider = new ApplicationOAuthProvider(PublicClientId);
                options.AccessTokenProvider = app.CreateAccessTokenProvider();
                options.RefreshTokenProvider = app.CreateRefreshTokenProvider();
                options.AuthorizationCodeProvider = app.CreateAuthorizationCodeProvider();

                //在生产模式下设 AllowInsecureHttp = false
                options.AllowInsecureHttp = true;
            });

            app.UseCors(string.Empty);
            app.UseMvc();
        }
        
    }
}
