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

        public List<ListAllProductView> GetListAllProduct(int CategoryID)
        {
            var model = db.ListAllProductViews.Where(p=>p.CategoryID == CategoryID).ToList();
            return model;
        }

        public List<Category> GetCategory()
        {
            var model = db.Categories.ToList();
            return model;
        }
    }
}
