using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Model.Dao;
using Model.EF;
using ShoesStore.Utils;

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace ShoesStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductDetails()
        {
            return View();
        }

        public ActionResult SingleProduct(int ShoeID, int ColorID)
        {
            var model = new ProductDao().GetProductDetails(ShoeID, ColorID);
            return View(model);
        }

        public ActionResult TemplateProduct(int ShoeID, int ColorID)
        {
            var model = new ProductDao().GetTemplateProduct(ShoeID, ColorID);
            return PartialView(model);
        }

        public ActionResult TemplateBestSellerProduct(int ShoeID, int ColorID)
        {
            var model = new ProductDao().GetTemplateProduct(ShoeID, ColorID);
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult ChangeImage(int ShoeID, int ColorID)
        {

            var model = new ProductDao().GetProductDetails(ShoeID, ColorID);
            return Json(new
            {
                ImageList = model.ImageProductList,
                Price = model.ProductCurrent.Price.ToString()
            });
        }

        public ActionResult SizePartial()
        {
            var model = new SizeDao().GetAllShoeSize();
            return PartialView(model);
        }

        public ActionResult ColorPartial()
        {
            var model = new ColorDao().GetAllColor();
            return PartialView(model);
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

        /*public ActionResult ProductFilterListPartial(int CategoryID = 1)
        {
            var model = new CategoryDao().GetListAllProduct(CategoryID);
            return PartialView();
        }*/

        public int pageSize = 2;//Số bài post cần hiển thị ra

        [HttpPost]
        public JsonResult ProductPagination(int ? page, int CategoryID = 1)
        {
            var model = new CategoryDao().GetListAllProduct(CategoryID);

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
                categoryid = CategoryID
            });
        }


    }
}