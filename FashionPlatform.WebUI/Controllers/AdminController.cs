﻿using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using FashionPlatform.Domain.UserAndRole;
using FashionPlatform.Domain.UserAndRole.Infrastructure;
using FashionPlatform.WebUI.Models;

namespace FashionPlatform.WebUI.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                IdentityResult result =
                    await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }
    }
}