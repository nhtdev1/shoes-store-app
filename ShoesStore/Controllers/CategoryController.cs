using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using ShoesStore.Utils;

namespace ShoesStore.Controllers
{
    public class CategoryController : Controller
    {
        /// <summary>
        /// Số bài post cần hiển thị ra
        /// </summary>
        public int pageSize = 4;


        // GET: Category

        //Trang danh mục sản phẩm
        public ActionResult Index(int CategoryID = 1)
        {
            var model = new CategoryDao().GetListAllProduct(CategoryID);
            return View(model);
        }


        [ChildActionOnly]
        public ActionResult CategoryPartial()
        {
            var dao = new CategoryDao();

            ViewBag.All = dao.GetProductTotal(0);
            ViewBag.MEN = dao.GetProductTotal(1);
            ViewBag.WOMEN = dao.GetProductTotal(2);
            ViewBag.KIDS = dao.GetProductTotal(3);
            var model = new CategoryDao().GetCategory();
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult FindProduct(int? page, double size)
        {
            var model = new CategoryDao().GetListAllProduct();

            page = page ?? 1;
            int start = (int)(page - 1) * pageSize;
            int totalPage = model.Count();
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);

            var filter = model.Skip(start).Take(pageSize).ToList();

            string data = HtmlMvcHelper.RenderViewToString(ControllerContext,
                    "~/Views/Shared/_LayoutListProduct.cshtml",
                    filter, true);

            return Json(new
            {
                data = data,
                pageCurrent = page,
                numSize = numSize,
            });
        }


        [HttpPost]
        public JsonResult ProductPagination(int? page, string[] conditions)
        {
            var model = new CategoryDao().FilterProductBy(conditions);

            page = page ?? 1;
            int start = (int)(page - 1) * pageSize;
            int totalPage = model.Count();
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);

            var filter = model.Skip(start).Take(pageSize).ToList();

            string dataHtml = HtmlMvcHelper.RenderViewToString(ControllerContext,
                    "~/Views/Shared/_LayoutListProduct.cshtml",
                    filter, true);

            return Json(new
            {
                data = dataHtml,
                pageCurrent = page,
                numSize = numSize,
                conditions = conditions
            });
        }

        public ActionResult SizePartial()
        {
            var model = new SizeDao().GetAllShoeSize();
            return PartialView(model);
        }

        public ActionResult ColorPartial()
        {
            return PartialView();
        }

        public ActionResult PricePartial()
        {
            return PartialView();
        }

        public ActionResult ProductFilterBarPartial()
        {
            return PartialView();
        }

        public ActionResult ProductFilterListPartial()
        {
            return PartialView();
        }

    }
}