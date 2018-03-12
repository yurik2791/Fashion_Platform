using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FashionPlatform.Domain.UserAndRole;
using FashionPlatform.Domain.UserAndRole.Infrastructure;
using FashionPlatform.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace FashionPlatform.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "В доступе отказано" });
            }
            ViewBag.returnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel details, string ReturnUrl)
        {
            AppUser user = await UserManager.FindAsync(details.Name, details.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Некорректное имя или пароль.");
            }
            else
            {
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);

                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, ident);
                if (String.IsNullOrEmpty(ReturnUrl))
                {
                    return RedirectToAction("List", "Product");
                }
                return Redirect(ReturnUrl);
            }

            return View(details);
        }

        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult> Register(AppUser model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.
        //        AppUser user = new AppUser { UserName = model.Email, Email = model.Email, Year = model.Year };
        //        IdentityResult result = await UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Login", "Account");
        //        }
        //        else
        //        {
        //            foreach (string error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error);
        //            }
        //        }
        //    }
        //    return View(model);
        //}

        [Authorize]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Hom");
        }
        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}