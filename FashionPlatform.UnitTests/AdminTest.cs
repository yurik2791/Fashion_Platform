using System;
using System.Collections.Generic;
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
    public class AdminTest
    {
        [TestMethod]
        public void Can_Send_Product_List_To_View()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns(new List<Product>
            {
                new Product {ProductId = 1, Name = "Product1"},
                new Product {ProductId = 2, Name = "Product2"},
                new Product {ProductId = 3, Name = "Product3"},
                new Product {ProductId = 4, Name = "Product4"},
                new Product {ProductId = 5, Name = "Product5"}
            });

            AdminController controller = new AdminController(mock.Object);
            List<Product> result = ((IEnumerable<Product>) controller.Index().ViewData.Model).ToList();

            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[0].ProductId, 1);
        }

        [TestMethod]
        public void Can_Edit_Product()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns(new List<Product>
            {
                new Product {ProductId = 1, Name = "Product1"},
                new Product {ProductId = 2, Name = "Product2"},
                new Product {ProductId = 3, Name = "Product3"},
                new Product {ProductId = 4, Name = "Product4"},
                new Product {ProductId = 5, Name = "Product5"}
            });

            AdminController controller = new AdminController(mock.Object);

            Product result = (Product) controller.Edit(1).ViewData.Model;

            Assert.AreEqual(result.ProductId,1);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            AdminController controller = new AdminController(mock.Object);
           
            // Организация - создание объекта
            Product product = new Product {Name = "TestProduct"};

            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(product);

            // Утверждение - проверка того, что к хранилищу производится обращение
            mock.Verify(p=>p.SaveProduct(product));
            // Утверждение - проверка типа результата метода
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Save_InValid_Changes()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            AdminController controller = new AdminController(mock.Object);

            // Организация - создание объекта
            Product product = new Product { Name = "TestProduct" };

            controller.ModelState.AddModelError("error","error");
            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(product);

            // Утверждение - проверка того, что к хранилищу производится обращение
            mock.Verify(p => p.SaveProduct(It.IsAny<Product>()),Times.Never());
            // Утверждение - проверка типа результата метода
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Product()
        {
            Product product = new Product {Name = "Product1", ProductId = 1};
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns(new List<Product>
            {
                new Product {ProductId = 1, Name = "Product1"},
                new Product {ProductId = 2, Name = "Product2"},
                new Product {ProductId = 3, Name = "Product3"},
                new Product {ProductId = 4, Name = "Product4"},
                new Product {ProductId = 5, Name = "Product5"}
            });

            AdminController controller = new AdminController(mock.Object);
            controller.Delete(product.ProductId);
            mock.Verify(p=>p.DeleteProduct(product.ProductId));
        }
    }
}
