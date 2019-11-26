using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class PaymentDao
    {
        ShoesStore db = new ShoesStore();

        public List<PayMethod> GetPayMethods()
        {
            return db.PayMethods.Where(p=>p.Status == true).ToList();
        }

        public bool Insert(PayMethod pay)
        {
            try
            {
                db.PayMethods.Add(pay);
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
