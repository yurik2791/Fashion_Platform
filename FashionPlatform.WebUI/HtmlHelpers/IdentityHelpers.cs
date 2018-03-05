﻿using System.Web;
using System.Web.Mvc;
using FashionPlatform.Domain.UserAndRole.Infrastructure;
using Microsoft.AspNet.Identity.Owin;

namespace FashionPlatform.WebUI.HtmlHelpers
{

    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            AppUserManager mgr = HttpContext.Current
                .GetOwinContext().GetUserManager<AppUserManager>();

            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }
    }
}
