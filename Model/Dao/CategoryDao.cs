using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class CategoryDao
    {
        ShoesStore db = new ShoesStore();

        public List<ListAllProductView> GetListAllProduct()
        {
            var model = db.ListAllProductViews.ToList();
            return model;
        }

        public List<SingleProductList> GetListAllProduct(int CategoryID)
        {
            var model = db.ListSingleProductViews.Where(p=>p.CategoryID == CategoryID).ToList();

            List<SingleProductList> lsp = new List<SingleProductList>();
            foreach (var item in model)
            {
                SingleProductList sp = new SingleProductList();
                sp.SingleProduct = item;
                sp.OtherColorProductList = db.ListAllProductViews.Where(p => p.ShoeID == item.ShoeID).ToList();
                lsp.Add(sp);
            }
            return lsp;
        }

        public List<Category> GetCategory()
        {
            var model = db.Categories.ToList();
            return model;
        }
    }
}
