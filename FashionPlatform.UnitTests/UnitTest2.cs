using System;
using System.Collections.Generic;
using System.Linq;
using FashionPlatform.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FashionPlatform.UnitTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Can_Add_New_Item_To_Cart()
        {
            // Организация - создание нескольких тестовых
            Product prod1 = new Product {ProductId = 1, Name = "Product1"};
            Product prod2 = new Product {ProductId = 2, Name = "Product2"};

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.Add(prod1, 1);
            cart.Add(prod2, 1);
            List<CartLine> Lines = cart.Lines.ToList();

            //Утверждение
            Assert.AreEqual(Lines.Count, 2);
            Assert.AreEqual(Lines[0].Product, prod1);
            Assert.AreEqual(Lines[1].Product, prod2);
        }

        [TestMethod]
        public void Can_Add_Existing_Item_To_Cart()
        {
            // Организация - создание нескольких тестовых
            Product prod1 = new Product {ProductId = 1, Name = "Product1"};
            Product prod2 = new Product {ProductId = 2, Name = "Product2"};

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.Add(prod1, 1);
            cart.Add(prod2, 1);
            cart.Add(prod1, 5);
            List<CartLine> Lines = cart.Lines.ToList();

            //Утверждение
            Assert.AreEqual(Lines.Count, 2);
            Assert.AreEqual(Lines[0].Quantity, 6);
            Assert.AreEqual(Lines[1].Quantity, 1);
        }
        [TestMethod]
        public void Can_Remove_Item_from_the_Cart()
        {
            // Организация - создание нескольких тестовых
            Product prod1 = new Product {ProductId = 1, Name = "Product1"};
            Product prod2 = new Product {ProductId = 2, Name = "Product2"};
            Product prod3 = new Product {ProductId = 3, Name = "Product3"};
            Product prod4 = new Product {ProductId = 4, Name = "Product4"};

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.Add(prod1, 1);
            cart.Add(prod2, 1);
            cart.Add(prod4, 3);
            cart.Add(prod3, 2);

            cart.RemoveLine(prod1);

            //Утверждение
            Assert.AreEqual(cart.Lines.Count(), 3);
            Assert.AreEqual(cart.Lines.Where(p => p.Product == prod1).Count(), 0);
        }

        [TestMethod]
        public void Can_Calculate_Total_Cost()
        {
            // Организация - создание нескольких тестовых
            Product prod1 = new Product { ProductId = 1, Name = "Product1", Price = 2};
            Product prod2 = new Product { ProductId = 2, Name = "Product2",Price = 8};
            Product prod3 = new Product { ProductId = 3, Name = "Product3",Price = 5};
            Product prod4 = new Product { ProductId = 4, Name = "Product4",Price = 3};

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.Add(prod1, 1);
            cart.Add(prod2, 1);
            cart.Add(prod3, 3);
            cart.Add(prod4, 2);

            decimal result = cart.ComputeTotalValue();

            //Утверждение
            Assert.AreEqual(result, 31);
            
        }

        [TestMethod] public void Can_Clear_All_Products()
        {
            // Организация - создание нескольких тестовых
            Product prod1 = new Product { ProductId = 1, Name = "Product1", Price = 2 };
            Product prod2 = new Product { ProductId = 2, Name = "Product2", Price = 8 };
            Product prod3 = new Product { ProductId = 3, Name = "Product3", Price = 5 };
            Product prod4 = new Product { ProductId = 4, Name = "Product4", Price = 3 };

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.Add(prod1, 1);
            cart.Add(prod2, 1);
            cart.Add(prod3, 3);
            cart.Add(prod4, 2);

            cart.Clear();

            //Утверждение
            Assert.AreEqual(cart.Lines.Count(), 0);

        }
    }
}
