using System.Net;
using System.Net.Http;
using System.Web.Http;

using ScrumBoard.Domain;
using ScrumBoard.Services;

namespace ScrumBoard.Web.Controllers.Api
{
    public class ProjectController : ApiController
    {
        private ProjectService service;

        public ProjectController(ProjectService service)
        {
            this.service = service;
        }

        public HttpResponseMessage Post(Project project)
        {            
            if (!ModelState.IsValid) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            service.Create(project);

            return Request.CreateResponse(HttpStatusCode.Created, project);
        }
    }
}
