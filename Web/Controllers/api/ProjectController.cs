using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ScrumBoard.Domain;
using ScrumBoard.Services;
using ScrumBoard.Web.Models;

namespace ScrumBoard.Web.Controllers.Api
{
    public class ProjectController : ApiController
    {
        private readonly ProjectService service;

        public ProjectController(ProjectService service)
        {
            this.service = service;
        }

        public HttpResponseMessage Post(NewProject project)
        {            
            if (!ModelState.IsValid) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            var entity = project.ToEntity();

            service.Create(entity);

            var response = Request.CreateResponse(HttpStatusCode.Created, project);
            
            AddResourceLocation(entity, response);

            return response;
        }

        private void AddResourceLocation(Project project, HttpResponseMessage response)
        {
            string uri = Url.Link("DefaultApi", new { controller = "Project", id = project.Code });
            
            response.Headers.Location = new Uri(uri);
        }

        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, service.GetByCode(id));
        }
    }
}
