using NUnit.Framework;
using ShoesStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShoesStore.Test.Controller
{
    [TestFixture]
    class LoginControllerTest
    {
        LoginController loginController;

        [SetUp]
        public void SetUp()
        {
            loginController = new LoginController();
        }

        [Test]
        public void WhenModelStateOfLoginControllerNotExistThenThrowException()
        {

            Assert.Throws<NullReferenceException>(() => loginController.Login(null,null));
        }

        [Test]
        public void IfUserInLoginPartialIsNotExistThenThrowException()
        {
            Assert.Throws<NullReferenceException>(() => loginController.LoginPartial(null));
        }

        [Test]
        public void WhenLoginThenThrowException()
        {
            Assert.Throws<NullReferenceException>(() => loginController.IsLogin());
        }
    }
}
