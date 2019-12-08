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

        public long Insert(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user.UserID;
            }
            catch
            {
                return 0;
            }
         
        }

        public bool Edit(User user)
        {
            try
            {
                var _user = db.Users.Find(user.UserID);
                _user.Name = user.Name;
                _user.Email = user.Email;
                _user.DayOfBirth = user.DayOfBirth;
                _user.Phone = user.Phone;
                _user.Address = user.Address;
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
