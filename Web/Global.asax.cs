using System;
using System.Globalization;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using ScrumBoard.Web.App_Start;
using ScrumBoard.Web.Controllers;

namespace ScrumBoard.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            
            //TODO: decide if we are logging the exception here or in the controller. My vote goes to the controller GAK

            Response.Clear();

            var httpException = exception as HttpException;

            if (httpException == null) return;

            var config = (CustomErrorsSection)WebConfigurationManager.GetSection("system.web/customErrors");

            if (!UseCustomErrors(config)) return;

            var routeData = GetErrorRouteData(httpException, config);

            // Pass exception details to the target error View.
            routeData.Values.Add("error", exception);

            // Clear the error on server.
            Server.ClearError();

            // Avoid IIS7 getting in the middle
            Response.TrySkipIisCustomErrors = true;

            Response.StatusCode = httpException.GetHttpCode();

            // Call target Controller and pass the routeData.
            IController errorController = new ErrorController();

            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }

        private bool UseCustomErrors(CustomErrorsSection config)
        {
            return config.Mode == CustomErrorsMode.On ||
                   (config.Mode == CustomErrorsMode.RemoteOnly && Request.Url.Host != "localhost");
        }

        private RouteData GetErrorRouteData(HttpException httpException, CustomErrorsSection config)
        {
            var routeData = new RouteData();

            routeData.Values.Add("controller", "Error"); //TODO: get this value from the configuration to. Need to be able to parse route info here

            var statusCode = httpException.GetHttpCode().ToString(CultureInfo.InvariantCulture);

            routeData.Values.Add("action", config.Errors[statusCode] != null
                                             ? config.Errors[statusCode].Redirect
                                             : config.DefaultRedirect);

            return routeData;
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    var context = Context;

        //    var error = context.Server.GetLastError() as HttpException;

        //    if (error == null) return;

        //    var statusCode = error.GetHttpCode().ToString(CultureInfo.InvariantCulture);

        //    // we can still use the web.config custom errors information to
        //    // decide whether to redirect
        //    var config = (CustomErrorsSection)WebConfigurationManager.GetSection("system.web/customErrors");

        //    if (!UseCustomErrors(config, context)) return;

        //    // set the response status code
        //    context.Response.StatusCode = error.GetHttpCode();

        //    // set this so that IIS doesn’t try to hijack the 404 and show it’s own error page. Without this, when remote users try to navigate to an invalid URL they will see the IIS 404 error page instead of your custom FailWhale page.
        //    context.Response.TrySkipIisCustomErrors = true;

        //    // Server.Transfer to correct ASPX file for error
        //    HttpContext.Current.Server.Transfer(config.Errors[statusCode] != null
        //                                            ? config.Errors[statusCode].Redirect
        //                                            : config.DefaultRedirect);
        //}


    }
}