using Model.Dao;
using ShoesStore.Models;
using ShoesStore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
        public ActionResult LoginSuccessfullyPartial(string ReturnUrl)
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
        public ActionResult Login(LoginModel model,string ReturnUrl)
        {
            var dao = new AccountDao();
            if (ModelState.IsValid)
            {

                var result = dao.Login(model.Email, model.Password);
                if (result)
                {
                    var ac = dao.GetAccount(model.Email);
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
            if (ReturnUrl.ToString().Trim().ToLower().Contains("user"))
            {
                return Redirect("/Home/Index");
            }
            return Redirect(ReturnUrl);
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

        [HttpPost]
        public JsonResult SignUp(string email, string password)
        {
            var _acc = new AccountDao().GetAccount(email);
            bool res = false;
            string message = "";
            if (_acc != null)
            {
                message = "Email already exists";
            }
            else
            {
                res = new AccountDao().SignUp(email, password);
                if(res == true)
                {
                    message = "Register Successfully";
                }
                else
                {
                    message = "Register failed";
                }
            }
            return Json(new
            {
                message = message,
                status = res
            });
        }
<<<<<<< HEAD
=======

        [HttpGet]
        public ActionResult ForgotPass(string email, string password)
        {

            return View();
        }



        [HttpGet]
        public ActionResult ForgotPassConfirm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassConfirm(string newPass, string newPass2, string vericode)
        {
            ViewBag.Message = "";
            var acc = new AccountDao().GetAccount(Session["email"].ToString());

            if (newPass != newPass2)
            {
                ViewBag.Message = "Please verify new password";
                return View();
            }
            else
            {
                if (vericode.Trim() != ((string)Session["verificationCode"]).Trim())
                {
                    ViewBag.Message = "Wrong verification code";
                    return View();
                }
                else
                {
                    bool res = new AccountDao().ChangePass(acc.AccID, newPass);
                    ViewBag.Message = "Your password has been changed successfully"; //ko biet lam cho hien

                    return RedirectToAction("Index", "Home");
                }
            }

        }

        [HttpPost]
        public JsonResult SendVeriCode(string toEmailAddress)
        {
            Session["verificationCode"] = GenVeriCode();
            Session["email"] = toEmailAddress;
            var acc = new AccountDao().GetAccount(toEmailAddress);
            if (acc == null)
            {
                return Json(new
                {
                    status = false
                });
            }
            else
            {

                bool status = new MailHelper().ReplySubscribe(toEmailAddress,
                    "SHOES STORE COMPANY",
                    "Enter the code below to confirm your password reset <br />" + Session["verificationCode"]);

                return Json(new
                {
                    link = Url.Action("ForgotPassConfirm", "Login"),
                    status = status
                });
            }
        }

        private string GenVeriCode()
        {
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            if (r.Distinct().Count() == 1)
            {
                r = GenVeriCode();
            }
            return r;
        }

        public ActionResult LoginIconPartial()
        {
            var user = Session[UserSession] as UserLogin;
            return PartialView(user);
        }
>>>>>>> update linh tinh
    }
}