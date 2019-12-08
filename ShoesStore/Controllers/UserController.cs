using Model.Dao;
using Model.EF;
using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesStore.Controllers
{
    public class UserController : Controller
    {
        public const string UserSession = "UserSession";

        // GET: User
        public ActionResult ViewProfile()
        {
            var user = Session[UserSession] as UserLogin;
            User model = null;
            if (user != null)
            {
                model = new UserDao().GetUser(user.UserID);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            var user = Session[UserSession] as UserLogin;
            User model = null;
            if (user != null)
            {
                model = new UserDao().GetUser(user.UserID);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditProfile(User user)
        {

<<<<<<< HEAD
            //var _user = Session[UserSession] as UserLogin;
            //User model = null;
            //if (_user != null)
            //{
            //    model = new UserDao().GetUser(_user.UserID);
            //}
=======
>>>>>>> update linh tinh
            bool res = new UserDao().Edit(user);
            return View(user);
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            var user = Session[UserSession] as UserLogin;
            Account model = null;
            if (user != null)
            {
                model = new AccountDao().GetAccount(user.UserName);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ResetPassword(long accID, string oldPass, string newPass, string newPass2)
        {
            ViewBag.Message = "";
            var acc = new AccountDao().GetByID(accID);
            if (acc.Password != oldPass)
            {
                ViewBag.Message = "Wrong current password";
                ModelState.AddModelError("", "Wrong current password");
            }
            else
            if (newPass != newPass2)
            {
                ViewBag.Message = "Please verify new password";
            }
            else
            {
                bool res = new AccountDao().ChangePass(accID, newPass);
                if(res == true)
                {
                    ViewBag.Message = "Change password succesfully";
                }
                else
                {
                    ViewBag.Message = "Change password failed";

                }
            }
            return View(acc);
        }

    }
}