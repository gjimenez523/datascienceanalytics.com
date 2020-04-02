using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using datascienceanalytics.com.Configuration;
using datascienceanalytics.com.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace datascienceanalytics.com.Web.Startup
{
    [DependsOn(
        typeof(comApplicationModule), 
        typeof(comEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class comWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public comWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(comConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<comNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(comApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(comWebModule).GetAssembly());
        }
    }
}