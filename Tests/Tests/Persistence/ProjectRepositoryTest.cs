using System.Net;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Routing;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using ScrumBoard.Domain;
using ScrumBoard.Services;
using ScrumBoard.Web.Controllers.Api;
using ScrumBoard.Web.Models;
using ScrumBoard.Persistence;
using Common.Persistence;
using NHibernate;

using ScrumBoard.Persistence.Implementation;
namespace ScrumBoard.Tests.Persistence
{
    [TestClass]
    public class ProjectRepositoryTest
    {
        [TestMethod]
        public void SaveOrUpdateTest()
        {            
            //Save
            var sessionFactoryBuilder = new SessionFactoryBuilder();
            var currentSession = sessionFactoryBuilder.GetSessionFactory().OpenSession();

            var projectRepository = new ScrumBoard.Persistence.Implementation.ProjectRepository(currentSession);             
            var project = new Project{
                Name = "John Smith", 
                Vision = "My Vision",                 
            };
            projectRepository.SaveOrUpdate(project);            
            Assert.IsTrue(project.Id > 0);
        }
    }
}