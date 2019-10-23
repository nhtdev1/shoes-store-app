using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace ShoesStore.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        
        public ActionResult Index(int CategoryID = 1)
        {
            var model  = new CategoryDao().GetListAllProduct(CategoryID);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult CategoryPartial()
        {
            var model = new CategoryDao().GetCategory();
            return PartialView(model);
        }

    }
}