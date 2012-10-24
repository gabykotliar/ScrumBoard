using System.Net;
using System.Net.Http;
using System.Web.Http;

using ScrumBoard.Domain;

namespace ScrumBoard.Web.Controllers.Api
{
    public class ProjectController : ApiController
    {        
        public HttpResponseMessage Post(Project project)
        {
            //TODO: fix this validation that is not working
            if (!ModelState.IsValid) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            //TODO: create project
            project.Id = 1;

            return Request.CreateResponse(HttpStatusCode.Created, project);
        }
    }
}
