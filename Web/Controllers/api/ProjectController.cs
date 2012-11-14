using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ScrumBoard.Domain;
using ScrumBoard.Services;

namespace ScrumBoard.Web.Controllers.Api
{
    public class ProjectController : ApiController
    {
        private readonly ProjectService service;

        public ProjectController(ProjectService service)
        {
            this.service = service;
        }

        public HttpResponseMessage Post([FromBody] Project project)
        {            
            if (!ModelState.IsValid) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            service.Create(project);

            var response = Request.CreateResponse(HttpStatusCode.Created, project);
            
            AddResourceLocation(project, response);

            return response;
        }

        private void AddResourceLocation(Project project, HttpResponseMessage response)
        {
            string uri = Url.Link("DefaultApi", new { id = project.Id });
            response.Headers.Location = new Uri(uri);
        }
    }
}
