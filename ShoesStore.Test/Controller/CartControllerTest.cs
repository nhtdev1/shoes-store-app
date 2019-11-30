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
    class CartControllerTest
    {
        CartController cartController;

        [SetUp]
        public void SetUp()
        {
            cartController = new CartController();
        }

        [Test]
        public void UpdateQuantityNotExistParamaterThenThrowException()
        {
            Assert.Throws<NullReferenceException>(() => cartController.UpdateQuantity(-1, -1, -1,-1));
        }

        [Test]
        public void UpdateCartNotExistParamaterThenThrowException()
        {
            Assert.Throws<NullReferenceException>(() => cartController.UpdateCart(-1, -1, -1));
        }

        [Test]
        public void UpdateSizeNotExistParamaterThenThrowException()
        {
            Assert.Throws<NullReferenceException>(() => cartController.UpdateSize(-1, -1, -1));
        }

        [Test]
        public void UpdateCostNotExistParamaterThenThrowException()
        {
            Assert.Throws<NullReferenceException>(() => cartController.UpdateCost(-1, -1, "-1"));
        }

        [Test]
        public void UpdatePaymentNotExistParamaterThenThrowException()
        {
            Assert.Throws<NullReferenceException>(() => cartController.Payment("", "", "", "", "", "", "", "", "", "", "", "", ""));
        }


        [Test]
        public void TestModelOfCartPartial()
        {
            Assert.Throws<NullReferenceException>(()=> cartController.CartPartial());
        }

        [Test]
        public void TestModelOfCheckout()
        {
            Assert.Throws<NullReferenceException>(() => cartController.Checkout());
        }
    }
}
