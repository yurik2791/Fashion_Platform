using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using FashionPlatform.Domain.Abstract;
using FashionPlatform.Domain.Entities;
using FashionPlatform.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FashionPlatform.UnitTests
{
    [TestClass]
    public class ImageTest
    {
        [TestMethod]
        public void Can_Retrieve_Image_Data()
        {
            Product product = new Product
            {
                ProductId = 2,
                Name = "Product2",
                ImageData = new byte[] { },
                ImageMimeType = "image/png"
            };
            Mock<IProductRepository> mock=new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {ProductId = 1, Name = "Product1"},
                product,
                new Product {ProductId = 3, Name = "Product3"},
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);

            ActionResult result = controller.GetImage(2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual(product.ImageMimeType, ((FileResult)result).ContentType);
        }

        [TestMethod]
        public void Can_Retrieve_Image_Data_For_Invalid_Id()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {ProductId = 1, Name = "Product1"},
                new Product {ProductId = 3, Name = "Product3"},
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            ActionResult result = controller.GetImage(10);

            Assert.IsNull(result);
        }
    }
}
