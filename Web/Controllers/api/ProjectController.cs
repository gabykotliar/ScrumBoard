using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

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

            ICollection<ValidationResult> validationRestuts;

            var updated = service.TryCreate(entity, out validationRestuts);

            if (!updated)
            {                
                ModelState.AddModelError("Code", "The selected code was already used.");

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            var response = Request.CreateResponse(HttpStatusCode.Created, project);

            AddResourceLocation(entity, response);

            return response;
            
        }

        private void AddResourceLocation(Project project, HttpResponseMessage response)
        {
            string uri = Url.Link("DefaultApi", new { id = project.Code });
            response.Headers.Location = new Uri(uri);
        }

        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, service.GetByCode(id));
        }
    }
}
