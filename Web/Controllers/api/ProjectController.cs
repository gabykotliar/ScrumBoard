using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ScrumBoard.Domain;

namespace ScrumBoard.Web.Controllers.api
{
    public class ProjectController : ApiController
    {
        // GET api/project
        public IEnumerable<Project> Get()
        {
            return new Project[] { };
        }

        // GET api/project/5
        public Project Get(int id)
        {
            return new Project();
        }
        
        public HttpResponseMessage Post(Project project)
        {
            //TODO: fix this validation that is not working
            if(!ModelState.IsValid) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            //TODO: create project

            project.Id = 1;

            return Request.CreateResponse(HttpStatusCode.Created, project);
        }

        // PUT api/project/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/project/5
        public void Delete(int id)
        {
        }
    }
}
