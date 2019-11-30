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
    class ProductControllerTest
    {
        ProductController productController;

        [SetUp]
        public void SetUp()
        {
            productController = new ProductController();
        }

        [Test]
        public void SingleProductHasParameterNotExistButModelIsExist()
        {
            var rs = productController.SingleProduct(-1, -1) as ViewResult;
            Assert.AreEqual(true, rs.Model != null);
        }

        [Test]
        public void TemplateProductHasParameterNotExistButModelIsExist()
        {
            var rs = productController.TemplateProduct(-1, -1) as PartialViewResult;
            Assert.AreEqual(true,rs.Model != null);
        }


        [Test]
        public void TemplateBestSellerProductHasParameterNotExistButModelIsExist()
        {
            var rs = productController.TemplateBestSellerProduct(-1, -1) as PartialViewResult;
            Assert.AreEqual(true, rs.Model !=null);
        }

        [Test]
        public void ChangeImageHasParameterNotExistThenThrowException()
        {
            Assert.Throws<NullReferenceException>(() => productController.ChangeImage(-1, -1));
        }
    }
}
