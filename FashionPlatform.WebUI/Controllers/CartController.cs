using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionPlatform.Domain.Abstract;
using FashionPlatform.Domain.Entities;
using FashionPlatform.WebUI.Models;

namespace FashionPlatform.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IProductRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;

        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModels
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int productID, string returnUrl)//Добавление продукта в корзину 
        {
            Product product = (Product)repository.Products.Where(p => p.ProductId == productID).FirstOrDefault();
            if (product != null)
            {
                cart.Add(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });// В представление передаем ссылкы откуда мы попали в корзину
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productID, string returnUrl) // Удаление продукта из корзины
        {
            Product product = (Product)repository.Products.Where(p => p.ProductId == productID).FirstOrDefault();
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });// В представление передаем ссылкы откуда мы попали в корзину
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}