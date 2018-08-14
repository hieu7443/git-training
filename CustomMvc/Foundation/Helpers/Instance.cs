using CustomMvc.Foundation.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomMvc
{
    public static class Instance
    {
        public static void Init()
        {
            RegisterRoutes(RouteTable.Routes);
            RegisterConnectionString();
            ControllerBuilder.Current.SetControllerFactory(typeof(CustomControllerFactory));
        }
        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.Clear();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Sitemap",
                url: "sitemap.xml",
                defaults: new { controller = "Base", action = "Sitemap" }
            );
            routes.MapRoute(
                name: "Robots",
                url: "robots.txt",
                defaults: new { controller = "Base", action = "Robots" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{*url}",
                defaults: new { controller = "Base", action = "Index" }
            );
        }
        private static void RegisterConnectionString()
        {
            string conn = ConfigurationManager.ConnectionStrings["Entities"]?.ConnectionString;
            if (String.IsNullOrEmpty(conn))
            {
                conn = "Data Source=NET-HIEUNT;Initial Catalog=Demo;Integrated Security=SSPI";
            }
            Foundation.Database.CustomDbContext.SetConnectionString(conn);
        }
    }
}