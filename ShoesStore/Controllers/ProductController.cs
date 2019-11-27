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

    }
}