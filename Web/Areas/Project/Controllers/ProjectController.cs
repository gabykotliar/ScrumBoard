using System.Web.Mvc;

namespace ScrumBoard.Web.Areas.Project.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Dashboard(string id)
        {
            return View(new Domain.Project { Name = string.Format("My Project ({0})", id) });
        }

    }
}
