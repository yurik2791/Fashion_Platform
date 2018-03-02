using System.Linq;
using System.Web.Mvc;
using FashionPlatform.Domain.Abstract;
using FashionPlatform.Domain.Entities;
using FashionPlatform.WebUI.Models;

namespace FashionPlatform.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public int pageSize = 3;

        // GET: Product
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel  // Передаем всю нужную информацью в представление через данный обьект 
            {
                Products = repository.Products // Сортировка продуктов и отоброжение их на странице в количестве PageSize
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * pageSize)// В зависимости на какой мы странице пропускаем продукты
                    .Take(pageSize), // Выбираем количество продуктов равных PageSize
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Products.Count(p => category==null||p.Category==category)
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
