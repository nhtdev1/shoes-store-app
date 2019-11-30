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
    class CategoryControllerTest
    {
        CategoryController categoryController;

        [SetUp]
        public void SetUp()
        {
            categoryController = new CategoryController();
        }

        [Test]
        public void ReturnModelOfIndexIsEmptyWhenNotExistParameter()
        {
            var rs = categoryController.Index(-1) as ViewResult;
            Assert.AreEqual("", rs.Model);
        }

        [Test]
        public void FindProductNotExistParamaterThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => categoryController.FindProduct(-1, -1));
        }


        [Test]
        public void ProductPaginationNotExistParamaterThenThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => categoryController.ProductPagination(-1, new[] { "" }));

        }

        [Test]
        public void ReturnModelIsExistOfSizePartial()
        {
            var rs = categoryController.SizePartial() as PartialViewResult;
            Assert.AreEqual(true, rs.Model != null);
        }
    }
}
