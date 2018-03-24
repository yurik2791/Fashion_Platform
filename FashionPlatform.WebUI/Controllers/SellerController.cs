using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using FashionPlatform.Domain.Abstract;
using FashionPlatform.Domain.Concrete;
using FashionPlatform.Domain.Entities;
using FashionPlatform.WebUI.Models;

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
            Product p = repository.Products.FirstOrDefault(m => m.ProductId == productId)??new Product(); // получаем продукт который будет модифицирован
            ProductViewModel productViewModel = new ProductViewModel // Создаем экземпляр класса для передачи для передачи данных в наше представление
            {
                Category = p.Category,
                Description = p.Description,
                ImageData = p.ImageData,
                ImageMimeType = p.ImageMimeType,
                ProductId = p.ProductId,
                Price = p.Price,
                Name = p.Name,
                CountryId = p.CountryId,
                CountryName = repository.Countries.FirstOrDefault(s => s.CountryId == p.CountryId)?.CountryName,
                ShoeId = p.ShoeId,
                ShoeName = repository.Shoes.FirstOrDefault(s => s.ShoeId == p.ShoeId)?.ShoeName,
                UpWearId = p.UpWearId,
                UpWearName = repository.UpWears.FirstOrDefault(s => s.UpWearId == p.UpWearId)?.UpWearName,
                DownWearId = p.DownWearId,
                DownWearName = repository.DownWears.FirstOrDefault(s => s.DownWearId == p.DownWearId)?.DownWearName,
                DressCodeId = p.DressCodeId,
                DressCodeName = repository.DressCodes.FirstOrDefault(s => s.DressCodeId == p.DressCodeId)?.DressCodeName,
                FiberId = p.FiberId,
                FiberName = repository.Fibers.FirstOrDefault(s => s.FiberId == p.FiberId)?.FiberName,
                ProductDestinationId = p.ProductDestinationId,
                ProductDestinationName = repository.ProductDestinasions.FirstOrDefault(s => s.ProductDestinationId == p.ProductDestinationId)?.ProductDestinationName,
                StyleId = p.StyleId,
                StyleName = repository.Styles.FirstOrDefault(s => s.StyleId == p.StyleId)?.StyleName,
                AccessoryId = p.AccessoryId,
                AccessoryName = repository.Accessories.FirstOrDefault(s => s.AccessoryId == p.AccessoryId)?.AccessoryName,
                ClothId = p.ClothId,
                ClothName = repository.Clothes.FirstOrDefault(s => s.ClothId == p.ClothId)?.ClothName

            };
            List<Shoe> listShoes = repository.Shoes.ToList();                       //Создаем списки для елементов DropDownList
            List<Accessory> listAccessories = repository.Accessories.ToList();
            List<Country> listCountries = repository.Countries.ToList();
            var listClothes = (from cloth in repository.Clothes                     // Список элементов сгрупированных по типу волокна
                               join type in repository.TypesCloths on cloth.TypeClothId equals type.TypeClothId
                               select new
                               {
                                   ClothName = cloth.ClothName,
                                   ClothId = cloth.ClothId,
                                   typeCloth = type.TypeClothName
                               }).ToList();
            List<DownWear> listDownWears = repository.DownWears.ToList();
            List<UpWear> listUpWears = repository.UpWears.ToList();
            List<DressCode> listDressCodes = repository.DressCodes.ToList();
            var listFibers = (from fib in repository.Fibers
                              join type in repository.TypesFibers on fib.TypeFiberId equals type.TypeFiberId
                              select new
                              {
                                  FiberName = fib.FiberName,
                                  FiberId = fib.FiberId,
                                  typeFiber = type.TypeFiberName
                              }).ToList();
            List<ProductDestination> listProductDestinations = repository.ProductDestinasions.ToList();
            List<Style> listStyles = repository.Styles.ToList();


            ViewBag.Shoes = new SelectList(listShoes, "ShoeId", "ShoeName");
            ViewBag.Accessories = new SelectList(listAccessories, "AccessoryId", "AccessoryName");
            ViewBag.Clothes = new SelectList(listClothes, "ClothId", "ClothName", "typeCloth", productViewModel.ClothId);
            ViewBag.Countries = new SelectList(listCountries, "CountryId", "CountryName");
            ViewBag.DownWears = new SelectList(listDownWears, "DownWearId", "DownWearName");
            ViewBag.UpWears = new SelectList(listUpWears, "UpWearId", "UpWearName");
            ViewBag.DressCodes = new SelectList(listDressCodes, "DressCodeId", "DressCodeName");
            ViewBag.Fibers = new SelectList(listFibers, "FiberId", "FiberName", "typeFiber", productViewModel.FiberId);
            ViewBag.ProductDestinations = new SelectList(listProductDestinations, "ProductDestinationId", "ProductDestinationName");
            ViewBag.Styles = new SelectList(listStyles, "StyleId", "StyleName");
            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    ProductId = productViewModel.ProductId,
                    Name = productViewModel.Name,
                    Description = productViewModel.Description,
                    Category = productViewModel.Category,
                    Price = productViewModel.Price,
                    ClothId = productViewModel.ClothId,
                    CountryId = productViewModel.CountryId,
                    DressCodeId = productViewModel.DressCodeId,
                    ShoeId = productViewModel.ShoeId,
                    StyleId = productViewModel.StyleId,
                    UpWearId = productViewModel.UpWearId,
                    DownWearId = productViewModel.DownWearId,
                    ProductDestinationId = productViewModel.ProductDestinationId,
                    FiberId = productViewModel.FiberId,
                    AccessoryId = productViewModel.AccessoryId
                };
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = $"Change saved in product: {product.Name}.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(productViewModel);
            }

        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit", new ProductViewModel());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"Product {deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}