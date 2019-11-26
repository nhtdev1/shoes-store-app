using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDao
    {
        ShoesStore db = new ShoesStore();


        public long Insert(PurchaseOrder order)
        {
            try
            {
                db.PurchaseOrders.Add(order);
                db.SaveChanges();
                return order.PoID;
            }
            catch
            {
                return 0;
            }
        }
    }
}
