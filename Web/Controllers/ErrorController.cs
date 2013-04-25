using System.Web.Mvc;

namespace ScrumBoard.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult PageNotFound404()
        {
            return View("404");
        }

        public ActionResult InternalServerError500()
        {
            return View("Error");
        }
    }
}
