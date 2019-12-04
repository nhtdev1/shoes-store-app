using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using ShoesStore.Utils;

namespace ShoesStore.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult BannerPartial()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult DirectoriesPartial()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult TrendingProductPartial()
        {
            var model = new ProductDao().GetListTrendingProduct();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult OfferPartial()
        {

            var model = new ProductDao().GetBestSellerProducts();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult BestSellersPartial()
        {
            var model = new ProductDao().GetBestSellerProducts();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult BlogPartial()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult SubscribePartial()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult ViewedProductsPartial()
        {
            
            return PartialView(ProductsLogHelper.history);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }
    }
}