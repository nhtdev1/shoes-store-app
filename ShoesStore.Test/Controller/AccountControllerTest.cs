using NUnit.Framework;
using ShoesStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Test.Controller
{
    [TestFixture]
    class AccountControllerTest
    {
        AccountController accountController;

        [SetUp]
        public void SetUp()
        {
            accountController = new AccountController();
        }
    }
}
