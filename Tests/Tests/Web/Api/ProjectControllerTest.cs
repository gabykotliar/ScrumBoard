using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using ScrumBoard.Domain;
using ScrumBoard.Services;
using ScrumBoard.Web.Controllers.Api;

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
        public void CreateTest()
        {
            var project = new Project();
            var serviceMock = new Mock<ProjectService>();

            serviceMock.Setup(s => s.Create(project));

            var controller = new ProjectController(serviceMock.Object);

            var route = new HttpRouteData(new HttpRoute(), new HttpRouteValueDictionary { { "controller", "Products" }, { "action", "Post" } });            

            ContextUtil.SetControllerContext(controller, 
                                             request: new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/products"),
                                             routeData: route);

            controller.Configuration.Routes.MapHttpRoute(
                                                name: "DefaultApi",
                                                routeTemplate: "api/{controller}/{id}",
                                                defaults: new { id = RouteParameter.Optional });

            var response = controller.Post(project);

            serviceMock.Verify();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
