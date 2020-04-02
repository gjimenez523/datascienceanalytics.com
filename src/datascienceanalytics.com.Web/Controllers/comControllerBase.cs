using Abp.AspNetCore.Mvc.Controllers;

namespace datascienceanalytics.com.Web.Controllers
{
    public abstract class comControllerBase: AbpController
    {
        protected comControllerBase()
        {
            LocalizationSourceName = comConsts.LocalizationSourceName;
        }
    }
}