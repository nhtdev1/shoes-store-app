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

        public ActionResult Login(LoginModel model,string ReturnUrl)
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
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "The account or password does not exist");
                }
            }
            return Redirect(ReturnUrl);

        }

        public ActionResult LogOut(string ReturnUrl)
        {
            Session[UserSession] = null;

            return Redirect(ReturnUrl);
        }
        public ActionResult LoginPartial(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            var user = Session[UserSession] as UserLogin;
            return PartialView(user);
        }

        public ActionResult LoginPopupPartial(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return PartialView(null);
        }

        [HttpPost]
        public JsonResult IsLogin()
        {
            var userSession = Session[UserSession] as UserLogin;
            return Json(new
            {
                status = userSession == null ? false : true
            });
        }
    }
}