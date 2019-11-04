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

        public List<TemplateProductView> GetListAllProduct()
        {
            var model = db.TemplateProductViews.ToList();
            return model;
        }

        public List<TemplateProductView> GetListAllProduct(int CategoryID)
        {
            return db.TemplateProductViews.Where(p=>p.CategoryID == CategoryID).ToList();
        }

        public List<Category> GetCategory()
        {
            var model = db.Categories.ToList();
            return model;
        }
    }
}
