using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDao
    {
        ShoesStore db = new ShoesStore();

        public User GetUser(long ID)
        {
            return db.Users.SingleOrDefault(p => p.UserID == ID);

        }
    }
}
