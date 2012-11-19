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

namespace ScrumBoard.Tests.Web.Api
{
    [TestClass]
    public class ProjectControllerTest
    {
        [TestMethod]
        [Description("It should be possible to inject dependencies through the constructor")]
        public void ConstructorTest()
        {
            var controller = new ProjectController(new Mock<ProjectService>().Object);

            controller.Should().NotBeNull();
        }

        [TestMethod]
        public void PostProductCallProductServiceTest()
        {
            var projectDTO = new NewProject();
            var project = new Project();
            var serviceMock = new Mock<ProjectService>();

            serviceMock.Setup(s => s.Create(project));

            var controller = GetApiProjectController(serviceMock);

            var response = controller.Post(projectDTO);

            serviceMock.Verify();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [TestMethod]
        public void PostProductReturnsCreatedStatusCodeTest()
        {
            var controller = GetApiProjectController(new Mock<ProjectService>());

            var response = controller.Post(new NewProject());

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [TestMethod]
        public void PostProductReturnsRightLocationTest()
        {
            var controller = GetApiProjectController(new Mock<ProjectService>());

            var mock = new Mock<NewProject>();
            mock.Setup(m => m.ToEntity()).Returns(new Project{ Id = 123 });

            var response = controller.Post(mock.Object);

            response.Headers.Location.Should().Be("http://localhost/api/projects/123");
        }

        [TestMethod]
        public void PostProductReturnsBadRequestStatusCodeForInvalidModelTest()
        {
            var controller = GetApiProjectController(new Mock<ProjectService>());

            controller.ModelState.AddModelError("Name", "Name is required");

            var response = controller.Post(new NewProject());

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private static ProjectController GetApiProjectController(Mock<ProjectService> serviceMock)
        {
            var controller = new ProjectController(serviceMock.Object);

            ContextUtil.SetApiControllerContext(
                controller,
                request: new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/projects"),
                routeData:
                    new HttpRouteData(
                        new HttpRoute(), new HttpRouteValueDictionary { { "controller", "projects" }, { "action", "Post" } }));
            return controller;
        }
    }
}
