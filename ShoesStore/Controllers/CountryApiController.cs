using ShoesStore.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesStore.Controllers
{
    public class CountryApiController : Controller
    {
        // GET: CountryApi
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetProvinces(int Id)
        {
            var provinces = new ProvinceClient().findAll().Where(p => p.CountryId == Id).ToList();

            return Json(new
            {
                provinces = provinces,
                status = true
            });
        }

        [HttpPost]
        public JsonResult GetDistricts(int Id)
        {
            var districts = new DistrictClient().findAll().Where(p => p.ProvinceId == Id).ToList();
            return Json(new
            {
                districts = districts,
                status = true
            });
        }

        [HttpPost]
        public JsonResult GetWards(int Id)
        {
            var wards = new WardClient().findAll().Where(p => p.DistrictID == Id).ToList();
            return Json(new
            {
                wards = wards,
                status = true
            });
        }
    }
}