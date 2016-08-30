using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace NJLFramework.WebApi
{
    public partial class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            ConfigEnvironment();
        }

        public IConfigurationRoot Configuration { get; set; }

        public static string PublicClientId { get; private set; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return ConfigServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            ConfigSetting(app, env, loggerFactory);
        }
    }
}
