using System.Web.Mvc;

namespace ScrumBoard.Web.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}
