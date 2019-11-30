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
    class UserDaoTest
    {
        UserDao userDao;

        [SetUp]
        public void SetUp()
        {
            userDao = new UserDao();
        }

        [Test]
        public void ReturnZeroWhenUserIsNull()
        {
          
            Assert.AreEqual(0, userDao.Insert(null));
        }

    }
}
