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
        public const string ViewedProducts = "ViewedProducts";

        public ActionResult ProductDetails()
        {
            return View();
        }

        public ActionResult SingleProduct(int ShoeID, int ColorID)
        {
            var model = new ProductDao().GetProductDetails(ShoeID, ColorID);

            var productLog = new ProductDao().GetTemplateProduct(ShoeID, ColorID);

            if (!ProductsLogHelper.history.Exists(p=>p.MainProduct.ColorID == productLog.MainProduct.ColorID))
            {
                ProductsLogHelper.history.Add(productLog);
            }

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

        public ActionResult BarcodeScanner()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetBarcode(string code)
        {
            bool status = false;
            string data = "<h4>No results found, please scan again</h4>";
            if (!code.Trim().Equals(""))
            {
                var model = new ProductDao().GetProductBarcode(int.Parse(code));

                data = HtmlMvcHelper.RenderViewToString(ControllerContext,
                        "~/Views/Shared/_LayoutProductBarcode.cshtml",
                        model, true);
                status = true;
            }
            return Json(new
            {
                data = data,
                status = status,
            });;
        }
    }
}