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

        public List<ViewTopTrending> GetListTrendingProduct()
        {
            var model = db.ViewTopTrendings.OrderByDescending(p => p.Views).Take(8).ToList();
            return model;
        }

        public ViewShoeDetail GetDetailsOfProduct(int ShoeID,string Code)
        {
            return db.ViewShoeDetails.AsNoTracking().Where(p => p.ShoeID == ShoeID && p.Code.Equals(Code)).OrderByDescending(p => p.Likes).SingleOrDefault();
        }

        public List<ViewShoeDetail> GetListDetailsOfProductSameType(long ShoeID)
        {
            return db.ViewShoeDetails.AsNoTracking().Where(p => p.ShoeID == ShoeID).OrderByDescending(p => p.Likes).ToList();
        }

 
    }
}
