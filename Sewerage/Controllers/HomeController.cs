using System.Web.Mvc;

namespace Sewerage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Url = "http://localhost/Videos/e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism";
                           
            return View();
        }
    }
}
