using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

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
            var model = new ProductDao().GetProductDetails(ShoeID,ColorID);
            return View(model);
        }

        public ActionResult TemplateProduct(int ShoeID, int ColorID)
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
            }); ;
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
    }
}