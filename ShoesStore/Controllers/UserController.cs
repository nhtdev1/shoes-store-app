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

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}