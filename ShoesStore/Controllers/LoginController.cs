using Model.Dao;
using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesStore.Controllers
{
    public class LoginController : Controller
    {
        public const string UserSession = "UserSession";
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            var dao = new AccountDao();
            if (ModelState.IsValid)
            {

                var result = dao.Login(model.UserName, model.Password);
                if (result)
                {
                    var ac = dao.GetAccount(model.UserName); 
                    var user = new UserLogin();
                    user.AccountID = ac.AccID;
                    user.UserID = long.Parse(ac.UserID.ToString());
                    user.UserName = ac.UserName;
                    user.Email = ac.Email;
                    Session.Add(UserSession, user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The account or password does not exist");
                }
            }
            return Redirect("/Home/Index");

        }

        public ActionResult LoginPartial()
        {
            var user = Session[UserSession] as UserLogin;
            return PartialView(user);
        }

        public ActionResult LoginPopupPartial()
        {
            return PartialView(null);
        }
    }
}