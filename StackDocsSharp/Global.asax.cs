using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using StackDocsSharp.Services;

namespace StackDocsSharp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();

            container.Register<IHigher, Higher>();
            container.Register<IDataBase, DataBase>();
            container.Register<ILower, Lower>();
            container.Register<ICache, Caching>();

            container.Verify();

            ContainerInjector.Container = container;

        }
    }
}