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
    class OrderDaoTest
    {
        OrderDao orderDao;

        [SetUp]
        public void SetUp()
        {
            orderDao = new OrderDao();
        }

        [Test]
        public void ReturnZeroWhenOrderIsNull()
        {
            Assert.AreEqual(0, orderDao.Insert(null));
        }
    }
}
