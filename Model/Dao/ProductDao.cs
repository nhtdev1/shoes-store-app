
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

        //Lấy 8 sản phẩm trong vòng 30 ngày gần nhất có số lượt like nhiều nhất
        public List<TopTrendingView> GetListTrendingProduct()
        {
           return db.TopTrendingViews.OrderByDescending(p => p.LikeNumber).Take(8).ToList();

        }

        public List<BestSellerProduct> GetBestSellerProducts()
        {
            return db.BestSellerProducts.OrderByDescending(p => p.Total).ToList();
        }

        //Lấy một sản phẩm (kèm với danh sách màu khác) theo ID và ColorID
        public SingleProductList GetTemplateProduct(int ShoeID, int ColorID)
        {
            SingleProductList sp = new SingleProductList();
            sp.MainProduct =
                db.ProductViews.Where(p => p.ColorID == ColorID).SingleOrDefault();
            sp.OtherColorProductList =
                db.ProductViews.Where(p => p.ShoeID == ShoeID).ToList();
            return sp;
        }

        public ProductDetails GetProductDetails(int ShoeID, int ColorID)
        {
            ProductDetails pd = new ProductDetails();
            pd.ProductCurrent = db.ProductViews.Where(p=>p.ShoeID == ShoeID && p.ColorID==ColorID).SingleOrDefault();
            pd.ImageProductList = db.PhotoDescriptions.Where(p => p.ColorID == ColorID).Select(p => p.Image).OrderBy(p=>p).ToList();
            pd.SizeProductList = db.ProductSizeViews.Where(p => p.ShoeID == ShoeID).Select(p => p.Number.ToString()).ToList();

            pd.OtherColorProductList = db.ProductViews.Where(p => p.ShoeID == ShoeID).ToList();

            return pd;
        }
 
        public ProductView GetProduct(int ShoeID, int ColorID)
        {
            return db.ProductViews.Where(p => p.ColorID == ColorID && p.ShoeID == ShoeID).SingleOrDefault();
        }

        public List<double> GetSizes(int ShoeID)
        {
            var model = db.ProductSizeViews.Where(p => p.ShoeID == ShoeID).Select(p => p.Number).ToList();
            var listSize = new List<double>();
            model.ForEach(p =>
            {
                listSize.Add(double.Parse(p.ToString()));
            });
            return listSize;
        }

        public string GetColorName(long ColorID)
        {
            return db.Colors.SingleOrDefault(p => p.ColorID == ColorID).ColorName;
        }
    }
}
