using System.Web.Mvc;

namespace ScrumBoard.Web.Areas.Project.Controllers
{
    [OutputCache(CacheProfile = "domainForms")]
    public class ProjectController : Controller
    {
        public ActionResult Dashboard(string projectKey)
        {
            return View();
        }
    }
}
