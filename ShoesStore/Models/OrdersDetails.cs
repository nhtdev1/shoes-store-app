using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesStore.Models
{
    public class OrdersDetails
    {
        public List<CartItem> Cart { get; set; }

        public double Cost { get; set; }

        public double Tax { get; set; }

        public double Shipping { get; set; }
    }
}