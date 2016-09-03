using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.IO;
using System.Resources;
using System.Collections.Concurrent;
using System.Reflection;

namespace NJLFramework.Localization
{
    /// <summary>
    /// 自定义字符串资源工厂
    /// </summary>
    public class CustomResourceManagerStringLocalizerFactory : IStringLocalizerFactory
    {
        readonly IHostingEnvironment _hostingEnvironment;
        readonly string _resourcePath;
        readonly ConcurrentDictionary<string, ResourceManagerStringLocalizer> _localizerCache
            = new ConcurrentDictionary<string, ResourceManagerStringLocalizer>();
        readonly IResourceNamesCache _resourceNameCache = new ResourceNamesCache();
        readonly string _assemblyName;

        public CustomResourceManagerStringLocalizerFactory(IHostingEnvironment hostingEnvironment, IOptions<CustomLocalizationOptions> localizationOptions)
        {
            _hostingEnvironment = hostingEnvironment;
            _resourcePath = localizationOptions.Value.ResourcesPath ?? string.Empty;
            if(!string.IsNullOrEmpty(_resourcePath))
            {
                _resourcePath = _resourcePath.Replace(Path.AltDirectorySeparatorChar, '.')
                    .Replace(Path.DirectorySeparatorChar, '.') + ".";
            }

            _assemblyName = localizationOptions.Value.AssemblyName ?? string.Empty;
            if (string.IsNullOrWhiteSpace(_assemblyName))
            {
                _assemblyName = IntrospectionExtensions.GetTypeInfo(this.GetType()).Assembly.GetName().Name;
            }
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            if (resourceSource == null)
                throw new ArgumentNullException(nameof(resourceSource));

            var shortProjectName = IntrospectionExtensions.GetTypeInfo(resourceSource).Assembly.GetName().Name.Split('.').Last();
            return Create(shortProjectName);
        }

        /// <summary>
        /// 从指定的程序集加地资源
        /// </summary>
        /// <param name="baseName">资源基路径</param>
        /// <param name="location">程序集路径</param>
        /// <returns></returns>
        public IStringLocalizer Create(string baseName, string location)
        {
            if (string.IsNullOrWhiteSpace(baseName))
                throw new ArgumentNullException(nameof(baseName));

            location = string.IsNullOrWhiteSpace(location) ? _hostingEnvironment.ApplicationName : location;
            var shortProjectName = location.Split('.').Last();
            return Create(shortProjectName);


            //原始代码
            //baseName = $"{location}.{_resourcePath}{TrimPrefix(baseName, location + ".")}";
            //return _localizerCache.GetOrAdd($"B={baseName},L={location}", key => {
            //    var assembly = Assembly.Load(new AssemblyName(location));
            //    return new ResourceManagerStringLocalizer(new ResourceManager(baseName, assembly), assembly, baseName, _resourceNameCache);
            // });
        }

        /// <summary>
        /// 指定源项目的短项目名,如项目名称为NJLFramework.WebApi，则为WebApi,
        /// 计算方法是以"."分割的最后一段.
        /// </summary>
        /// <param name="projectShortName">短项目名</param>
        /// <returns></returns>
        private IStringLocalizer Create(string projectShortName)
        {
            var baseName = $"{_assemblyName}.{_resourcePath}{projectShortName}";
            return _localizerCache.GetOrAdd(baseName, key => {
                var assembly = Assembly.Load(new AssemblyName(_assemblyName));
                return new ResourceManagerStringLocalizer(new ResourceManager(baseName, assembly), assembly, baseName, _resourceNameCache);
            });
        }

        private string TrimPrefix(string name, string prefix)
        {
            if (name.StartsWith(prefix, StringComparison.Ordinal))
            {
                return name.Substring(prefix.Length);
            }
            return name;
        }
    }
}
