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

        public List<ViewListAllProduct> GetListAllProduct()
        {
            var model = db.ViewListAllProducts.ToList();
            return model;
        }

        public List<ViewListAllProduct> GetListAllProduct(int CategoryID)
        {
            var model = db.ViewListAllProducts.Where(p=>p.CategoryID == CategoryID).ToList();
            return model;
        }

        public List<Category> GetCategory()
        {
            var model = db.Categories.ToList();
            return model;
        }
    }
}
