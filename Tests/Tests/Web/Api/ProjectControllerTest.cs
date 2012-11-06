using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
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

            var ctx = CreateControllerContext();
            var controller = new ProjectController(serviceMock.Object);

            controller.ControllerContext = ctx;
            controller.Request = ctx.Request;
            controller.Configuration = ctx.Configuration;

            //controller.Request = new HttpRequestMessage(HttpMethod.Post, "http://server.com/foo");            
            //controller.Configuration = controller.ControllerContext.Configuration;                       

            var response = controller.Post(project);

            serviceMock.Verify();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        public HttpActionContext CreateActionContext(HttpControllerContext controllerContext = null, HttpActionDescriptor actionDescriptor = null)
        {
            HttpControllerContext context = controllerContext ?? CreateControllerContext();
            HttpActionDescriptor descriptor = actionDescriptor ?? new Mock<HttpActionDescriptor>() { CallBase = true }.Object;
            return new HttpActionContext(context, descriptor);
        }

        public HttpControllerContext CreateControllerContext(HttpConfiguration configuration = null, IHttpController instance = null, IHttpRouteData routeData = null, HttpRequestMessage request = null)
        {
            HttpConfiguration config = configuration ?? new HttpConfiguration();
            IHttpRouteData route = routeData ?? new HttpRouteData(new HttpRoute());
            HttpRequestMessage req = request ?? new HttpRequestMessage();
            req.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            req.Properties[HttpPropertyKeys.HttpRouteDataKey] = route;

            var context = new HttpControllerContext(config, route, req);
            if (instance != null)
            {
                context.Controller = instance;
            }
            context.ControllerDescriptor = CreateControllerDescriptor(config);

            return context;
        }

        public HttpControllerDescriptor CreateControllerDescriptor(HttpConfiguration config = null)
        {
            if (config == null)
            {
                config = new HttpConfiguration();
            }
            return new HttpControllerDescriptor { Configuration = config };
        }
    }
}
