using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web.Mvc;

using ScrumBoard.Domain;

namespace ScrumBoard.Web.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Dashboard(string id)
        {
            return View(new Project { Name = "My Project" });
        }

        public ActionResult New()
        {
            return View();
        }
    }
}
