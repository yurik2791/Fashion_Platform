﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FashionPlatform.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                null,
                "",
                new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null,
                    page = 1
                });
            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new
                {
                    controller = "Product",
                    action = "List",
                    category = (string) null,
                },
                constraints: new {page = @"\d+"});
            routes.MapRoute(
                name: null,
                url: "{category}",
                defaults: new
                {
                    controller = "Product",
                    action = "List",
                    page = 1
                });
            routes.MapRoute(
                name: null,
                url: "{category}/Page{page}",
                defaults: new
                {
                    controller = "Product",
                    action = "List"
                },
                constraints:new {page=@"\d+"});
            


            routes.MapRoute(
                name:"Paging",
                url:"Page{page}",
                defaults: new {controller = "Product", action = "List"});
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
