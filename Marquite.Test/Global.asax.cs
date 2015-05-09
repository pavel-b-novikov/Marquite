using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Razor;
using System.Web.Routing;
using System.Web.WebPages.Razor;
using System.Web.WebPages.Razor.Configuration;
using Marquite.Core;

namespace Marquite.Test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            ClassLookup.Init();
            ClassLookup.LoadFromAssembly(typeof(Bootstrap.Lookups).Assembly);
            ClassLookup.LoadFromAssembly(typeof(CssHoneypot.Lookups).Assembly);
            
            
        }
    }
}
