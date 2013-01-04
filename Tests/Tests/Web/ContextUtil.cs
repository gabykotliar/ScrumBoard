// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. Under Apache 2.0 Licence

using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Moq;

namespace ScrumBoard.Tests.Web
{
    internal static class ContextUtil
    {
        public static void SetApiControllerContext(ApiController controller, HttpConfiguration configuration = null, IHttpRouteData routeData = null, HttpRequestMessage request = null)
        {
            SetControllerContext(controller, configuration, routeData, request);

            AddDefaultApiRoute(controller.Configuration);
        }

        public static void SetControllerContext(ApiController controller, HttpConfiguration configuration = null, IHttpRouteData routeData = null, HttpRequestMessage request = null)
        {
            var ctx = CreateControllerContext(configuration, controller, routeData, request);

            controller.ControllerContext = ctx;
            controller.Request = ctx.Request;
            controller.Configuration = ctx.Configuration;
        }

        public static HttpControllerContext CreateControllerContext(HttpConfiguration configuration = null, IHttpController instance = null, IHttpRouteData routeData = null, HttpRequestMessage request = null)
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

        public static HttpActionContext CreateActionContext(HttpControllerContext controllerContext = null, HttpActionDescriptor actionDescriptor = null)
        {
            HttpControllerContext context = controllerContext ?? CreateControllerContext();
            HttpActionDescriptor descriptor = actionDescriptor ?? new Mock<HttpActionDescriptor> { CallBase = true }.Object;
            return new HttpActionContext(context, descriptor);
        }

        public static HttpActionContext GetHttpActionContext(HttpRequestMessage request)
        {
            HttpActionContext actionContext = CreateActionContext();
            actionContext.ControllerContext.Request = request;
            return actionContext;
        }

        public static HttpActionExecutedContext GetActionExecutedContext(HttpRequestMessage request, HttpResponseMessage response)
        {
            HttpActionContext actionContext = CreateActionContext();
            actionContext.ControllerContext.Request = request;
            HttpActionExecutedContext actionExecutedContext = new HttpActionExecutedContext(actionContext, null) { Response = response };
            return actionExecutedContext;
        }

        public static HttpControllerDescriptor CreateControllerDescriptor(HttpConfiguration config = null)
        {
            if (config == null)
            {
                config = new HttpConfiguration();
            }

            return new HttpControllerDescriptor { Configuration = config };
        }

        public static void AddDefaultApiRoute(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute(
                                              name: "DefaultApi",
                                              routeTemplate: "api/{controller}/{id}",
                                              defaults: new { id = RouteParameter.Optional });
        }
    }
}
