using Microsoft.AspNetCore.Mvc;

namespace datascienceanalytics.com.Web.Controllers
{
    public class BlogController : comControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(string postId)
        {
            return View("Post");
        }
        
    }
}