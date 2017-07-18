using MediaTrackerTest1;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MediaTrackerWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            initContainer();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //Dependancy injection initiliser 
        private void initContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IMovieService, MovieServiceImplementation>(Lifestyle.Scoped);
            container.Register<IBookInterface, BookServiceImplementation>(Lifestyle.Scoped);
            container.Register<ISeriesInterface, SeriesImplementation>(Lifestyle.Scoped);
            container.Register<IEpisodesInterface, EpisodesImplementation>(Lifestyle.Scoped);
            container.Register<IMovieTransitionInterface, MovieTransitionImplementation>(Lifestyle.Scoped);
            container.Register<IBookTransitionInterface, BookTransitionImplementation>(Lifestyle.Scoped);
            container.Register<ISeriesTransitionInterface, SeriesTransitionImplementation>(Lifestyle.Scoped);
            container.Register<IAppUser, AppUserService>(Lifestyle.Scoped);


            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
