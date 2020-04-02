using Microsoft.AspNetCore.Mvc;

namespace datascienceanalytics.com.Web.Controllers
{
    public class HomeController : comControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View("Contact");
        }
    }
}