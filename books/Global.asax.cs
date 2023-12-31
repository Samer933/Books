﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace books
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
             HttpConfiguration httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);

            GlobalConfiguration.Configure(httpConfig);

            // GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
