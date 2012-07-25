using System.Web.Mvc;
using Sewerage.Resources.Views.Home;

namespace Sewerage.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
