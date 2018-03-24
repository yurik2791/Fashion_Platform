using System.Collections.Generic;
using FashionPlatform.Domain.Abstract;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products { get { return context.Products; } }
        public IEnumerable<Cloth> Clothes { get { return context.Cloths; } }
        public IEnumerable<Shoe> Shoes { get { return context.Shoes; } }
        public IEnumerable<Accessory> Accessories { get { return context.Accessories; } }
        public IEnumerable<Country> Countries { get { return context.Countries; } }
        public IEnumerable<DownWear> DownWears { get { return context.DownWears; } }
        public IEnumerable<UpWear> UpWears { get { return context.UpWears; } }
        public IEnumerable<DressCode> DressCodes { get { return context.DressCodes; } }
        public IEnumerable<Fiber> Fibers { get { return context.Fibers; } }
        public IEnumerable<ProductDestination> ProductDestinasions { get { return context.ProductDestinasions; } }
        public IEnumerable<Style> Styles { get { return context.Styles; } }
        public IEnumerable<TypeCloth> TypesCloths { get { return context.TypesCloths; } }
        public IEnumerable<TypeFiber> TypesFibers { get { return context.TypesFibers; } }
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
                    dbEntry.ClothId = product.ClothId;
                    dbEntry.AccessoryId = product.AccessoryId;
                    dbEntry.CountryId = product.CountryId;
                    dbEntry.DownWearId = product.DownWearId;
                    dbEntry.UpWearId = product.UpWearId;
                    dbEntry.DressCodeId = product.DressCodeId;
                    dbEntry.ProductDestinationId= product.ProductDestinationId;
                    dbEntry.ShoeId = product.ShoeId;
                    dbEntry.StyleId = product.StyleId;
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
