using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailsDao
    {
        ShoesStore db = new ShoesStore();


        public bool Insert(PurchaseOrderDetail p)
        {
            try
            {
                db.PurchaseOrderDetails.Add(p);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
