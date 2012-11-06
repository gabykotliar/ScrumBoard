using System;
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

            var controller = new ProjectController(serviceMock.Object);

            SetControllerContext(controller);

            controller.Request.Method = HttpMethod.Post;
            controller.Request.RequestUri = new Uri("http://localhost/api/products");

            var response = controller.Post(project);

            serviceMock.Verify();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        private void SetControllerContext(ApiController controller)
        {
            var ctx = CreateControllerContext();

            controller.ControllerContext = ctx;
            controller.Request = ctx.Request;
            controller.Configuration = ctx.Configuration;
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

            if (routeData == null )
            {
                var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
                routeData = new HttpRouteData(route);
            }
            
            HttpRequestMessage req = request ?? new HttpRequestMessage();
            req.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            req.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;

            var context = new HttpControllerContext(config, routeData, req);

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
