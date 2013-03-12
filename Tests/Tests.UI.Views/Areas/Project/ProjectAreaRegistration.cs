using System.Web.Mvc;

namespace ScrumBoard.Web.Areas.Project
{
    public class ProjectAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Project"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Project_default",
                "Project/{projectKey}/{controller}/{action}/",
                new { controller = "Project", action = "Dashboard" });
        }
    }
}
