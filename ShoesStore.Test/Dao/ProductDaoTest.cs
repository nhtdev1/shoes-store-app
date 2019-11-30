using Model.Dao;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Test.Dao
{
    [TestFixture]
    class ProductDaoTest
    {
        ProductDao productDao;

        [SetUp]
        public void SetUp()
        {
            productDao = new ProductDao();
        }


        [Test]
        public void GetTemplateProductNullWhenShoeIdAndColorIdNotExist()
        {
            var rs = productDao.GetTemplateProduct(-1, -1);

            Assert.AreEqual(null, rs.MainProduct);
        }

        [Test]
        public void GetProductDetailsNullWhenShoeIdAndColorIdNotExist()
        {
            var rs = productDao.GetProductDetails(-1, -1);
            Assert.AreEqual(null, rs.ProductCurrent);
        }

        [Test]
        public void GetProductNullWhenShoeIdAndColorIdNotExist()
        {
            Assert.AreEqual(null, productDao.GetProduct(-1, -1));
        }

        [Test]
        public void GetProductSizeIsEmptyWhenShoeIdNotExist()
        {
            Assert.AreEqual("", productDao.GetSizes(-1));
        }

        [Test]
        public void WhenColorIdNotExistThenThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(()=> productDao.GetColorName(-1));
        }
    }
}
