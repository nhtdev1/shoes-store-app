using Model.Dao;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Test
{
    [TestFixture]
    class AccountDaoTest
    {
        AccountDao accountDao;

        [SetUp]
        public void SetUp()
        {
            accountDao = new AccountDao();
        }

        [Test]
        public void UsenameIsEmptyAndPasswordIsEmpty()
        {
            Assert.AreEqual(false, accountDao.Login("", ""));
        }


        [Test]
        public void UserNameOfAccountIsNullThenThrowArgumentNullException()
        {
            accountDao = new AccountDao();
            Assert.Throws<ArgumentNullException>(() => accountDao.GetAccount(null));
        }

    }
}
