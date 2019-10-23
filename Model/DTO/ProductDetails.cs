using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DTO
{
    public class ProductDetails
    {
        public ViewShoeDetail SingleProductDetails { get; set; }

        public List<ViewShoeDetail> ProductDetailsSameType { get; set; }
    }
}
