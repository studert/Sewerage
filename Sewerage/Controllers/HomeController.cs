using System.Web.Mvc;
using Sewerage.Resources.Views.Home;

namespace Sewerage.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Url = "http://localhost/Videos/e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism";
                           
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = AboutStrings.Subtitle;

            return View();
        }
    }
}
