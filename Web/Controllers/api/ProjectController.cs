using System;
using System.Collections.Generic;
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

        // POST api/project //[FromBody]string value
        public void Post(Project project)
        {

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
