using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace datascienceanalytics.com
{
    [DependsOn(
        typeof(comCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class comApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(comApplicationModule).GetAssembly());
        }
    }
}