﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionPlatform.WebUI.Controllers
{
    public class HomController : Controller // Test controler
    {
        [Authorize]
        public ActionResult Index()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Ключ", "Значение");

            return View(data);
        }
    }
}