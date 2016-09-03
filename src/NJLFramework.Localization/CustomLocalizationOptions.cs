using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJLFramework.Localization
{
    public class CustomLocalizationOptions: LocalizationOptions
    {
        /// <summary>
        /// 程序集名称
        /// </summary>
        public string AssemblyName { get; set; }
    }
}
