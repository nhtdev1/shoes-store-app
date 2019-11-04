using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class SingleProductList
    {
        public ProductView MainProduct { get; set; }

        public List<ProductView> OtherColorProductList { get; set; }
    }
}
