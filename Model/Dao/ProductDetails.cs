using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ProductDetails
    {   
        public ListAllProductView ProductCurrent { get; set; }

        public List<String> ImageProductList { get; set; }

        public List<String> SizeProductList { get; set; }

        public int Quantity { get; set; }

        public double Cost { get; set; }

        public List<ListAllProductView> OtherColorProductList { get; set; }
    }
}
