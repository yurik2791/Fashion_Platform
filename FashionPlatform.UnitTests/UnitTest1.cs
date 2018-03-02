using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FashionPlatform.Domain.Abstract;
using FashionPlatform.Domain.Entities;
using FashionPlatform.WebUI.Controllers;
using FashionPlatform.WebUI.HtmlHelpers;
using FashionPlatform.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FashionPlatform.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_paginate()
        {
            //Организация
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {ProductId = 1, Name = "Product1"},
                new Product {ProductId = 2, Name = "Product2"},
                new Product {ProductId = 3, Name = "Product3"},
                new Product {ProductId = 4, Name = "Product4"},
                new Product {ProductId = 5, Name = "Product5"}
            });
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;
            //Действие
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;
            List<Product> products = result.Products.ToList();
            //Утверждение
            Assert.IsTrue(products.Count == 2);
            Assert.AreEqual(products[0].ProductId, 4);
            Assert.AreEqual(products[1].ProductId, 5);
        } //Проверка размешение обьектов на странице

        [TestMethod]
        public void Can_generate_PageLinks()
        {
            // Организация - определение вспомогательного метода HTML - это необходимо
            // для применения расширяющего метода
            HtmlHelper myHelper = null;

            // Организация - создание объекта PagingInfo
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }


        // ...
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Организация (arrange)
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {ProductId = 1, Name = "Product1"},
                new Product {ProductId = 2, Name = "Product2"},
                new Product {ProductId = 3, Name = "Product3"},
                new Product {ProductId = 4, Name = "Product4"},
                new Product {ProductId = 5, Name = "Product5"}
            });
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPage, 2);
        }


        [TestMethod]
        public void Can_Filter_Product()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {ProductId = 1, Name = "Product1", Category="Cat1"},
                new Product {ProductId = 2, Name = "Product2", Category="Cat2"},
                new Product {ProductId = 3, Name = "Product3", Category="Cat1"},
                new Product {ProductId = 4, Name = "Product4", Category="Cat2"},
                new Product {ProductId = 5, Name = "Product5", Category="Cat3"}
            });
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            // Action
            List<Product> result = ((ProductsListViewModel)controller.List("Cat2", 1).Model)
                .Products.ToList();

            // Assert
            Assert.AreEqual(result.Count(), 2);
            Assert.IsTrue(result[0].Name == "Product2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "Product4" && result[1].Category == "Cat2");
        }

        [TestMethod]
        public void Can_Generate_Nav_Bar()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>()
            {
                new Product {ProductId = 1, Name = "Product1", Category = "Cat1"},
                new Product {ProductId = 2, Name = "Product2", Category = "Cat2"},
                new Product {ProductId = 3, Name = "Product3", Category = "Cat1"},
                new Product {ProductId = 4, Name = "Product4", Category = "Cat2"},
                new Product {ProductId = 5, Name = "Product5", Category = "Cat3"}
            });
           NavController target = new NavController(mock.Object);
            List < string > result = ((IEnumerable<string>) target.Menu().Model).ToList();

            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0], "Cat1");
        }

        [TestMethod]
        public void Indicaties_Selected_Category()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {ProductId = 3, Name = "Product3", Category = "Cat1"},
                new Product {ProductId = 4, Name = "Product4", Category = "Cat2"},
                new Product {ProductId = 5, Name = "Product5", Category = "Cat3"}
            });

            NavController target = new NavController(mock.Object);
            string result = (string) target.Menu("Cat2").ViewBag.CurrentCategory;
            Assert.AreEqual("Cat2", result);
        }

        [TestMethod]
        public void Count_Category_Product()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {ProductId = 1, Name = "Product1", Category = "Cat1"},
                new Product {ProductId = 2, Name = "Product2", Category = "Cat2"},
                new Product {ProductId = 3, Name = "Product3", Category = "Cat1"},
                new Product {ProductId = 4, Name = "Product4", Category = "Cat2"},
                new Product {ProductId = 5, Name = "Product5", Category = "Cat3"}
            });

            ProductController target = new ProductController(mock.Object);
            string category = "Cat1";
            ProductsListViewModel result = (ProductsListViewModel) target.List(category, 1).Model;

            Assert.AreEqual(result.Products.Count(),2);
        }

    }
}
