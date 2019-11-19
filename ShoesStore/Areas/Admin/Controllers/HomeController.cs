using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ShoesStore.Areas.Admin.Models;

namespace ShoesStore.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderDetails()
        {
            return View();
        }

        public ActionResult WaitToTakeOrders()
        {
            return View();
        }

        public ActionResult Column()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("1", 10));
            dataPoints.Add(new DataPoint("2", 30));
            dataPoints.Add(new DataPoint("3", 17));
            dataPoints.Add(new DataPoint("4", 39));
            dataPoints.Add(new DataPoint("5", 30));
            dataPoints.Add(new DataPoint("6", 25));
            dataPoints.Add(new DataPoint("7", 15));
            dataPoints.Add(new DataPoint("8", 10));
            dataPoints.Add(new DataPoint("9", 30));
            dataPoints.Add(new DataPoint("10", 17));
            dataPoints.Add(new DataPoint("11", 39));
            dataPoints.Add(new DataPoint("12", 30));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

        public ActionResult Column2()
        {
            List<DataPoint2> dataPoints = new List<DataPoint2>();

            dataPoints.Add(new DataPoint2(1496255400000, 2500));
            dataPoints.Add(new DataPoint2(1496341800000, 2790));
            dataPoints.Add(new DataPoint2(1496428200000, 3380));
            dataPoints.Add(new DataPoint2(1496514600000, 4940));
            dataPoints.Add(new DataPoint2(1496601000000, 4020));
            dataPoints.Add(new DataPoint2(1496687400000, 3390));
            dataPoints.Add(new DataPoint2(1496773800000, 4200));
            dataPoints.Add(new DataPoint2(1496860200000, 3150));
            dataPoints.Add(new DataPoint2(1496946600000, 3230));
            dataPoints.Add(new DataPoint2(1497033000000, 4200));
            dataPoints.Add(new DataPoint2(1497119400000, 5210));
            dataPoints.Add(new DataPoint2(1497205800000, 4940));
            dataPoints.Add(new DataPoint2(1497292200000, 3500));
            dataPoints.Add(new DataPoint2(1497378600000, 3790));
            dataPoints.Add(new DataPoint2(1497465000000, 3230));
            dataPoints.Add(new DataPoint2(1497551400000, 2900));
            dataPoints.Add(new DataPoint2(1497637800000, 3080));
            dataPoints.Add(new DataPoint2(1497724200000, 3370));
            dataPoints.Add(new DataPoint2(1497810600000, 2880));
            dataPoints.Add(new DataPoint2(1497897000000, 3170));
            dataPoints.Add(new DataPoint2(1497983400000, 3280));
            dataPoints.Add(new DataPoint2(1498069800000, 4070));
            dataPoints.Add(new DataPoint2(1498156200000, 5280));
            dataPoints.Add(new DataPoint2(1498242600000, 4970));
            dataPoints.Add(new DataPoint2(1498329000000, 2560));
            dataPoints.Add(new DataPoint2(1498415400000, 2790));
            dataPoints.Add(new DataPoint2(1498501800000, 3800));
            dataPoints.Add(new DataPoint2(1498588200000, 4400));
            dataPoints.Add(new DataPoint2(1498674600000, 4020));
            dataPoints.Add(new DataPoint2(1498761000000, 3900));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

        public ActionResult Column3()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("MEN", 50));
            dataPoints.Add(new DataPoint("WOMENS", 40));
            dataPoints.Add(new DataPoint("KIDS", 10));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
    }
}