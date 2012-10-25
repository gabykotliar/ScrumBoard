using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using ScrumBoard.Web.App_Start;

namespace ScrumBoard.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            var validatorFactory = new Domain.Validation.Infrastructure.ValidatorFactory();

            FluentValidation.Mvc.FluentValidationModelValidatorProvider.Configure(provider => { provider.ValidatorFactory = validatorFactory; });
            //FluentValidation.WebApi.FluentValidationModelValidatorProvider.Configure(provider => { provider.ValidatorFactory = validatorFactory; });

            //var fvProvider = ModelValidatorProviders.Providers.OfType<FluentValidationModelValidatorProvider>().First();

            //GlobalConfiguration.Configuration.Services.Add(typeof(System.Web.Http.Validation.ModelValidatorProvider), new FluentValidation.WebApi.FluentValidationModelValidatorProvider());
        }

    }
}