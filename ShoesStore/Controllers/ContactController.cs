using ShoesStore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesStore.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ReplaySubscribe(string toEmailAddress)
        {
            bool status = new MailHelper().ReplySubscribe(toEmailAddress, 
                "SHOES STORE COMPANY", 
                "Thank you for subscribing. We will send you the latest information");

            return Json(new
            {
                status = status
            });
        }

        [HttpPost]
        public JsonResult Feedback(string toEmailAddress)
        {
            bool status = new MailHelper().ReplySubscribe(toEmailAddress,
                "SHOES STORE COMPANY",
                "Thank you for subscribing. We will send you the latest information");

            return Json(new
            {
                status = status
            });
        }
    }
}