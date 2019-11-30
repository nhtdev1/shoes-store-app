using Model.Dao;
using Model.EF;
using ShoesStore.Models;
using ShoesStore.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesStore.Controllers
{
    public class CartController : Controller
    {
        public const string UserSession = "UserSession";

        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UpdateQuantity(int ShoeID, int ColorID, int quantity = 1, double size = 40)
        {
            ProductDao pd = new ProductDao();
            var cart = Session[CartSession];

            if (cart != null)
            {
                var list = (List<CartItem>)cart;

                var rs = list.Find(p => p.Product.ShoeID == ShoeID && p.Product.ColorID == ColorID && p.Size == size);
                if (rs != null)
                {
                    rs.Quantity += quantity;
                    rs.Size = size;
                    rs.SizeOther = pd.GetSizes(ShoeID);
                    Session[CartSession] = list;
                }
                else
                {
                    var item = new CartItem();
                    item.Product = pd.GetProduct(ShoeID, ColorID);
                    item.Quantity = quantity;
                    item.Size = size;
                    item.SizeOther = pd.GetSizes(ShoeID);
                    list.Add(item);
                    Session[CartSession] = list;
                }

            }
            else
            {
                var item = new CartItem();
                item.Product = pd.GetProduct(ShoeID, ColorID);
                item.Quantity = quantity;
                item.Size = size;
                item.SizeOther = pd.GetSizes(ShoeID);
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }


            int total = 0;
            double cost = 0.0;
            var l = (List<CartItem>)Session[CartSession];
            l.ForEach(p =>
            {
                total += p.Quantity;
                cost += p.Quantity * double.Parse(p.Product.Price.ToString());
            });

            return Json(new
            {

                status = true,
                cost = cost,
                total = total,
                cart = l
            });
        }

        [HttpPost]
        public JsonResult UpdateCart(int ShoeID, int ColorID, double size)
        {
            var listCart = Session[CartSession] as List<CartItem>;
            listCart.Remove(listCart.Find(p => p.Product.ShoeID == ShoeID
            && p.Product.ColorID == ColorID
            && p.Size == size));

            Session[CartSession] = listCart;
            int total = 0;
            double cost = 0.0;
            listCart.ForEach(p =>
            {
                total += p.Quantity;
                cost += p.Quantity * double.Parse(p.Product.Price.ToString());
            });

            return Json(new
            {
                status = true,
                cost = cost,
                total = total,
                cart = listCart
            });
        }

        [HttpPost]
        public JsonResult UpdateSize(int ShoeID, int ColorID, double NewSize)
        {
            var list = Session[CartSession] as List<CartItem>;

            var cartItem = list.Find(p => p.Product.ShoeID == ShoeID && p.Product.ColorID == ColorID);
            cartItem.Size = NewSize;
            Session[CartSession] = list;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult UpdateCost(int ShoeID, int ColorID, string quantity)
        {

            var list = Session[CartSession] as List<CartItem>;

            var cartItem = list.Find(p => p.Product.ShoeID == ShoeID && p.Product.ColorID == ColorID);
            cartItem.Quantity = int.Parse(quantity);
            Session[CartSession] = list;
            int total = 0;
            double cost = 0.0;
            list.ForEach(p =>
            {
                total += p.Quantity;
                cost += p.Quantity * double.Parse(p.Product.Price.ToString());
            });

            return Json(new
            {
                status = true,
                total = total,
                cost = cost
            });
        }

        public ActionResult CartPartial()
        {
            var model = Session[CartSession] as List<CartItem>;
            double cost = 0;
            if (model != null)
            {
                model.ForEach(p =>
                {
                    cost += p.Quantity * double.Parse(p.Product.Price.ToString());
                });

            }
            ViewBag.CostOfCart = cost;
            return PartialView(model);
        }

        public ActionResult Checkout()
        {
            var listCart = Session[CartSession] as List<CartItem>;
            int total = 0;
            double cost = 0.0;
            listCart.ForEach(p =>
            {
                total += p.Quantity;
                cost += p.Quantity * double.Parse(p.Product.Price.ToString());
            });
            var model = new OrdersDetails();
            model.Cart = listCart;
            model.Cost = cost;

            ViewBag.UserLogin = Session[UserSession] as UserLogin;
            ViewBag.Country = new CountryClient().findAll().ToList();

            return View(model);
        }

        public ActionResult Payment(string firstName,
            string lastName,
            string companyName,
            string phoneNumber,
            string emailAddress,
            string countryName,
            string provinceName,
            string districtName,
            string wardName,
            string notesInfo,
            string zipName,
            string orderNotes,
            string paymentMethod)
        {
            var userSession = Session[UserSession] as UserLogin;
            long userID;    
            if (userSession == null)
            {
                var user = new User();
                user.Name = firstName.Trim() + " " + lastName.Trim();
                user.Email = emailAddress.Trim();
                user.Phone = phoneNumber.Trim();
                user.Address = countryName.Trim() + ", " + provinceName.Trim() + ", " + districtName.Trim() + ", " + wardName.Trim();
                userID = new UserDao().Insert(user);

            }
            else
            {
                userID = userSession.UserID;
            }
            var purchaseOrder = new PurchaseOrder();
            purchaseOrder.OrderDate = DateTime.Now;
            purchaseOrder.Status = false;
            purchaseOrder.PayID = int.Parse(paymentMethod);
            new OrderDao().Insert(purchaseOrder);

            var listCart = Session[CartSession] as List<CartItem>;
            var odao = new OrderDetailsDao();
            var pdao = new ProductDao();

            listCart.ForEach(p =>
            {
                var value = new PurchaseOrderDetail();
                value.UserID = userID;
                value.PoID = purchaseOrder.PoID;
                value.ShoeID = long.Parse(p.Product.ShoeID.ToString());
                value.Quantity = p.Quantity;
                value.Cost = p.Quantity * p.Product.Price;
                value.Color = pdao.GetColorName(p.Product.ColorID);
                value.Size = decimal.Parse(p.Size.ToString());
                odao.Insert(value);
            });

            Session[CartSession] = null;

            return View();
        }

       

    }
}