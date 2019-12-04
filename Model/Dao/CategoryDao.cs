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
            return db.TemplateProductViews.Where(p => p.CategoryID == CategoryID).ToList();
        }

        public List<Category> GetCategory()
        {
            var model = db.Categories.ToList();
            return model;
        }

        public List<TemplateProductView> FilterProductBy(string[] conditions)
        {
            List<TemplateProductView> model = null;

            if (conditions[0].Trim().Equals(""))
            {
                model = db.TemplateProductViews.ToList();
            }
            else
            {
                model = db.TemplateProductViews
                    .AsEnumerable()
                    .Where(p => matchCategory(p, conditions[0])).ToList();
            }
            if (!conditions[1].Trim().Equals(""))
            {
                model = model.Where(p => matchSize(p, conditions[1])).ToList();
            }
            if (conditions[2].Trim().ToLower().Equals("multi-colour"))
            {
                model = model.Where(p => p.ColorName.Split(' ').Length > 1).ToList();
            }
            else if (!conditions[2].Trim().ToLower().Equals(""))
            {
                model = model.Where(p => matchColor(p, conditions[2])).ToList();
            }
            if (!conditions[3].Trim().Equals(""))
            {
                model = model.Where(p => matchContent(p, conditions[3])).ToList();
            }
            if (!conditions[5].Trim().Equals(""))
            {
                var arrayPrice = conditions[5].Trim().Split('-');
                double from = double.Parse(arrayPrice[0]);
                double to = double.Parse(arrayPrice[1]);
                model = model.Where(p => double.Parse(p.Price.ToString()) >= from
                && double.Parse(p.Price.ToString()) <= to).ToList();
            }
            if (conditions[4].Equals("2"))
            {
                model.Sort(new SortPriceHighToLow());

            }
            else if (conditions[4].Equals("3"))
            {
                model.Sort(new SortPriceLowToHigh());
            }
            else
            {
                model.Sort(new SortDate());
            }
            return model;
        }

        public bool matchCategory(TemplateProductView template, string categoryID)
        {
            int ID = int.Parse(categoryID.Trim());
            return template.CategoryID == ID;
        }

        public bool matchSize(TemplateProductView template, string size)
        {
            var model =
                db.ProductSizeViews.AsNoTracking().Where(p => p.ShoeID == template.ShoeID).ToList();
            foreach (var item in model)
            {
                if (double.Parse(item.Number.ToString()) == double.Parse(size))
                    return true;
            }

            return false;
        }

        public bool matchColor(TemplateProductView template, string colorName)
        {
            return template.ColorName.Trim().ToLower().Contains(colorName);
        }

        public bool matchContent(TemplateProductView template, string content)
        {
            return template.Name.Trim().ToLower().Contains(content) ||
                template.Descriptions.Trim().ToLower().Contains(content);
        }

        public int GetProductTotal(int categoryId)
        {
            if (categoryId == 0) return db.ProductViews.Count();
            else
            {
                return db.ProductViews.Where(p => p.CategoryID == categoryId).Count();
            }
        }
        private class SortPriceLowToHigh : IComparer<TemplateProductView>
        {
            public int Compare(TemplateProductView x, TemplateProductView y)
            {
                if (x == null || y == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {

                    if (x.Price > y.Price)
                    {
                        return 1;
                    }
                    else if (x.Price == y.Price)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        private class SortPriceHighToLow : IComparer<TemplateProductView>
        {
            public int Compare(TemplateProductView x, TemplateProductView y)
            {
                if (x == null || y == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {

                    if (x.Price < y.Price)
                    {
                        return 1;
                    }
                    else if (x.Price == y.Price)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        private class SortDate : IComparer<TemplateProductView>
        {
            public int Compare(TemplateProductView x, TemplateProductView y)
            {
                if (x == null || y == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return DateTime.Compare(DateTime.Parse(x.DateCreateColor.ToString()),
                        DateTime.Parse(y.DateCreateColor.ToString()));
                }
            }
        }
    }
}
