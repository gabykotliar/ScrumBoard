using System.Web.Mvc;

namespace ScrumBoard.Web.Controllers
{
    [OutputCache(CacheProfile = "domainForms")]
    public class ProjectsController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}
