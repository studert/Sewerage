using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using Sewerage.Models;
using Sewerage.Resources.Views.Home;

namespace Sewerage.Controllers
{
    [System.Web.Mvc.Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = AboutStrings.Subtitle;

            return View();
        }

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Documentation()
        {
            return File("~/Content/Bachelor Thesis.pdf", "application/pdf", "Bachelor Thesis - Tobias Studer.pdf");
        }

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Poster()
        {
            return File("~/Content/Poster.pdf", "application/pdf", "Video Streaming Web Application - Poster.pdf");
        }
    }
}
