using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using Model.DTO;

namespace ShoesStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductDetails()
        {
            return View();
        }

        public ActionResult SingleProduct(int ShoeID, string Code)
        {
            ProductDao pd = new ProductDao();

            ViewShoeDetail rs1 = pd.GetDetailsOfProduct(ShoeID,Code);
            List<ViewShoeDetail> rs2 = pd.GetListDetailsOfProductSameType(ShoeID);

            var model = new ProductDetails();
            model.SingleProductDetails = rs1;
            model.ProductDetailsSameType = rs2;
            return View(model);
        }

        [HttpPost]
        public JsonResult ChangeImage(int ShoeID, string Code)
        {
            ProductDao pd = new ProductDao();

            ViewShoeDetail rs1 = pd.GetDetailsOfProduct(ShoeID, Code);
            return Json(new
            {
                Image = rs1.Image,
                Price = rs1.Price
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
    }
}