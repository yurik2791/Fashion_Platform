using System;
using System.Web.Mvc;
using FashionPlatform.WebUI.Controllers;
using FashionPlatform.WebUI.Infrastructure.Abstract;
using FashionPlatform.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FashionPlatform.UnitTests
{
    [TestClass]
    public class AdminSecurityTest
    {
        [TestMethod]
        public void Can_Login_Admin_With_Valid_Credentials()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "12345")).Returns(true);

            LoginViewModels login = new LoginViewModels
            {
                Password = "12345",
                UserName = "admin"
            };
            AccountController controller = new AccountController(mock.Object);

            ActionResult result = controller.Login(login, "MyUrl");

            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("MyUrl", ((RedirectResult)result).Url);
        }

        [TestMethod]
        public void Can_Login_With_inValid_Credentials()
        {
            Mock<IAuthProvider> mock =new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("BadUserNme", "BadPassword")).Returns(false);

            LoginViewModels login = new LoginViewModels
            {
                UserName = "BadUserName",
                Password = "BadPassword"
            };

            AccountController controller = new AccountController(mock.Object);
            ActionResult result = controller.Login(login, "MyUrl");

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsFalse(((ViewResult) result).ViewData.ModelState.IsValid);

        }
    }
}
