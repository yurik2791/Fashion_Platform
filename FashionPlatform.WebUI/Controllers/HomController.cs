using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionPlatform.WebUI.Controllers
{
    public class HomController : Controller // Test controler
    {
        [Authorize]
        public string Index()
        {
            

            return "Hello world";
        }
    }
}