using System.Collections.Generic;
using FashionPlatform.Domain.Abstract;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products { get { return context.Products; } }
        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Category = product.Category;
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                    dbEntry.Cloth = product.Cloth;
                    dbEntry.Accessory = product.Accessory;
                    dbEntry.Country = product.Country;
                    dbEntry.DownWear = product.DownWear;
                    dbEntry.UpWear = product.UpWear;
                    dbEntry.DressCode = product.DressCode;
                    dbEntry.ProductDestinasion= product.ProductDestinasion;
                    dbEntry.Shoe = product.Shoe;
                    dbEntry.Style = product.Style;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            Product dbEntry;
            dbEntry = context.Products.Find(productId);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
