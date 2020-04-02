using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace datascienceanalytics.com.EntityFrameworkCore
{
    [DependsOn(
        typeof(comCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class comEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(comEntityFrameworkCoreModule).GetAssembly());
        }
    }
}