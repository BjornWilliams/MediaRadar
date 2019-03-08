using System.Web.Mvc;

namespace Hosting.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Brands()
        {
            return View();
        }

        public ActionResult Categories()
        {
           return View();
        }

        public ActionResult Companies()
        {
            return View();
        }
    }
}