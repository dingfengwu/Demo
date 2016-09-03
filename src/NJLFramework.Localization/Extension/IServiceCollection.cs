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
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace NJLFramework.Localization.Extension
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// 获取当前资源的定位器
        /// </summary>
        /// <param name="this">扩展对象</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public static void AddCustomLocalization(this IServiceCollection @this,Action<CustomLocalizationOptions> options)
        {
            @this.AddSingleton(typeof(IStringLocalizerFactory), typeof(CustomResourceManagerStringLocalizerFactory));
            @this.AddTransient(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));


            OptionsServiceCollectionExtensions.Configure<CustomLocalizationOptions>(@this, options);
        }

        /// <summary>
        /// 获取自定义HTML生成器
        /// </summary>
        /// <param name="this">扩展对象</param>
        /// <returns></returns>
        public static void AddCustomHtmlGenerator(this IServiceCollection @this)
        {
            @this.AddSingleton(typeof(IHtmlGenerator), typeof(CustomHtmlGenerator));
        }
    }
}
