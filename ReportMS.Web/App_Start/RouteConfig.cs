﻿using System.Web.Mvc;
using System.Web.Routing;

namespace ReportMS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Attribute Routing
            routes.MapMvcAttributeRoutes();

            // Tenant_default
            routes.MapRoute(
                name: "Tenant_default",
                url: "tenant-{tenant}/{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );

            // Default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}
