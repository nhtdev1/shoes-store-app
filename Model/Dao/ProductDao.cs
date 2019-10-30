using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ProductDao
    {
        private ShoesStore db = new ShoesStore();

        public List<TopTrendingProduct> GetListTrendingProduct()
        {
            List<TopTrendingProduct> listTrending = new List<TopTrendingProduct>();
            var model = db.TopTrendingViews.OrderByDescending(p => p.LikeNumber).Take(8).ToList();
            foreach(var item in model)
            {
                TopTrendingProduct tp = new TopTrendingProduct();
                tp.TopTrending = item;
                tp.OtherColorProductList = db.ListAllProductViews.Where(p => p.ShoeID == item.ShoeID).ToList();
                listTrending.Add(tp);
            }
            return listTrending;
        }


        public ProductDetails GetProductDetails(int ShoeID, int ColorID)
        {
            ProductDetails pd = new ProductDetails();
            pd.ProductCurrent = db.ListAllProductViews.Where(p=>p.ShoeID == ShoeID && p.ColorID==ColorID).SingleOrDefault();
            pd.ImageProductList = db.PhotoDescriptions.Where(p => p.ColorID == ColorID).Select(p => p.Image).ToList();
            pd.SizeProductList = db.ProductSizeViews.Where(p => p.ShoeID == ShoeID).Select(p => p.Number.ToString()).ToList();

            pd.OtherColorProductList = db.ListAllProductViews.Where(p => p.ShoeID == ShoeID).ToList();

            return pd;
        }
 
    }
}
