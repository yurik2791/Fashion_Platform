using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FashionPlatform.Domain.Abstract;

namespace FashionPlatform.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.CurrentCategory = category;
            IEnumerable<string> categories = repository
                .Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(p => p);
            return PartialView(categories);
        }
    }
}