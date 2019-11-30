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
    class PaymentDaoTest
    {
        PaymentDao paymentDao;

        [SetUp]
        public void SetUp()
        {
            paymentDao = new PaymentDao();
        }

        [Test]
        public void ReturnFalseWhenPaymentIsNull()
        {
            Assert.AreEqual(false, paymentDao.Insert(null));
        }
    }
}
