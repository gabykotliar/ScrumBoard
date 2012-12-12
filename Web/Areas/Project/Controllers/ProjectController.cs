using System.Web.Mvc;

namespace ScrumBoard.Web.Areas.Project.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Dashboard(string projectKey)
        {
            return View();
        }
    }
}
