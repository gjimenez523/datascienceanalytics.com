using Abp.AspNetCore.Mvc.Views;

namespace datascienceanalytics.com.Web.Views
{
    public abstract class comRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected comRazorPage()
        {
            LocalizationSourceName = comConsts.LocalizationSourceName;
        }
    }
}
