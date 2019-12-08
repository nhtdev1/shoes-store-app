using 
    Model.Dao;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Test.Dao
{
    [TestFixture]
    class OrderDaoDetailsTest
    {
        OrderDetailsDao orderDetails;

        [SetUp]
        public void SetUp()
        {
            orderDetails = new OrderDetailsDao();
        }

        [Test]
        public void ReturnFalseWhenOrderDetailsIsNull()
        {
            Assert.AreEqual(false, orderDetails.Insert(null));
        }
    }
}
