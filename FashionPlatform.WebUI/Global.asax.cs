using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FashionPlatform.Domain.Entities;
using FashionPlatform.WebUI.Infrastructure.Binders;

namespace FashionPlatform.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());// Добавили пользовательский обьект связывания данных
        }
    }
}
