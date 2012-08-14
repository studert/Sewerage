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

        [AllowAnonymous]
        public ActionResult Documentation()
        {
            return File("~/Content/Bachelor Thesis.pdf", "application/pdf", "Bachelor Thesis - Tobias Studer.pdf");
        }

        [AllowAnonymous]
        public ActionResult Poster()
        {
            return File("~/Content/Poster.pdf", "application/pdf", "Video Streaming Web Application - Poster.pdf");
        }
    }
}
