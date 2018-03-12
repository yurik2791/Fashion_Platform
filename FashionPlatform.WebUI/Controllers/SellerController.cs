using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionPlatform.Domain.Abstract;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.WebUI.Controllers
{
    public class SellerController : Controller
    {
        private IProductRepository repository;

        public SellerController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            //ProductListViewModel product = new ProductListViewModel
            //{
            //    Product = repository.Products.FirstOrDefault(p => p.ProductId == productId),
            //    Shoes = (Shoes) Enum.Parse(typeof(Shoes),
            //        repository.Products.FirstOrDefault(p => p.ProductId == productId).Shoe?? "Balletshoes")

            //};
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("Change saved in product: {0}.", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }

        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Product {0} was deleted", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}