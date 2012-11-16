using System.Web.Mvc;

namespace ScrumBoard.Web.Controllers
{
    public class ProjectsController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}
