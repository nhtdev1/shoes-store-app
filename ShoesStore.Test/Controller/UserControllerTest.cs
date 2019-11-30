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
    class UserControllerTest
    {
        UserController userController;

        [SetUp]
        public void SetUp()
        {
            userController = new UserController();
        }

        [Test]
        public void ViewProfileWhenSessionIsNullThenThrowException()
        {
            Assert.Throws<NullReferenceException>(() => userController.ViewProfile());
        }


        [Test]
        public void EditProfileWhenSessionIsNullThenThrowException()
        {
            Assert.Throws<NullReferenceException>(() => userController.EditProfile());
        }
    }
}
