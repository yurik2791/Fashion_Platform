﻿using System.Collections.Generic;
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
                    dbEntry.ClothId = product.ClothId;
                    dbEntry.AccessoryId = product.AccessoryId;
                    dbEntry.CountryId = product.CountryId;
                    dbEntry.DownWearId = product.DownWearId;
                    dbEntry.UpWearId = product.UpWearId;
                    dbEntry.DressCodeId = product.DressCodeId;
                    dbEntry.ProductDestinasionId= product.ProductDestinasionId;
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
