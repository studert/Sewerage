using System.Web.Mvc;

namespace Sewerage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "The inspection tool.";
            return View();
        }
    }
}
