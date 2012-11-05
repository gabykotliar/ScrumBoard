using System.Web.Mvc;

using ScrumBoard.Domain;

namespace ScrumBoard.Web.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Dashboard(string id)
        {
            return View(new Project { Name = string.Format("My Project ({0})", id) });
        }
        
        public ActionResult New()
        {
            return View();
        }
    }
}
