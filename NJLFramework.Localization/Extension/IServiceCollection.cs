using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;

namespace NJLFramework.Localization.Extension
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// 获取当前资源的定位器
        /// </summary>
        /// <param name="this"></param>
        /// <param name="context"></param>
        /// <param name="thisType"></param>
        /// <returns></returns>
        public static void AddCustomLocalization(this IServiceCollection @this,Action<CustomLocalizationOptions> options)
        {
            @this.AddSingleton(typeof(IStringLocalizerFactory), typeof(CustomResourceManagerStringLocalizerFactory));
            @this.AddTransient(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));


            OptionsServiceCollectionExtensions.Configure<CustomLocalizationOptions>(@this, options);
        }
    }
}
