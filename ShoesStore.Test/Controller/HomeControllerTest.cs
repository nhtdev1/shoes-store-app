using Model.EF;
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
    class HomeControllerTest
    {
        [Test]
        public void TestHomeControllerReturnIndex()
        {
            var obj = new HomeController();
            var actResult = obj.Index() as ViewResult;
            Assert.AreEqual("", actResult.ViewName);
        }

        [Test]
        public void TestTypeModelOfTrendingProductPartialAction()
        {
            var obj = new HomeController();
            var actResult = obj.TrendingProductPartial() as PartialViewResult;
            Assert.AreEqual(true, actResult.ViewData.Model.GetType().Equals(typeof(List<TopTrendingView>)));
        }

        [Test]
        public void TestTypeModelOfOfferPartialAction()
        {
            var obj = new HomeController();
            var actResult = obj.OfferPartial() as PartialViewResult;
            Assert.AreEqual(true, actResult.ViewData.Model.GetType().Equals(typeof(List<BestSellerProduct>)));
        }

        [Test]
        public void TestTypeModelOfBestSellersPartialAction()
        {
            var obj = new HomeController();
            var actResult = obj.OfferPartial() as PartialViewResult;
            Assert.AreEqual(true, actResult.ViewData.Model.GetType().Equals(typeof(List<BestSellerProduct>)));
        }
    }
}
