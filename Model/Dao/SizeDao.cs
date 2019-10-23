using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class SizeDao
    {
        ShoesStore db = new ShoesStore();

        public List<Size> GetAllShoeSize()
        {
            return db.Sizes.ToList();
        }
    }
}
