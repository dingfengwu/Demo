/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：StoreExtension.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-13 14:35:15
//----------------------------------------------------------------*/


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NJLFramework.Database
{
    public static class DatabaseExtension
    {
        public static void AddRepositories(this IServiceCollection @this)
        {
            @this.AddScoped(typeof(ApplicationDbContext));
            @this.AddScoped(typeof(DbContext),typeof(ApplicationDbContext));
            @this.AddScoped(typeof(EntityFrameworkRepositoryBase<>));
            @this.AddScoped(typeof(EntityFrameworkRepository));
            @this.AddScoped(typeof(EntityFrameworkRepositoryBase<,>));
            @this.AddScoped(typeof(EntityFrameworkRepository<>));

            @this.AddTransient(typeof(DbHelper), typeof(SqlHelper));
        }
    }
}
