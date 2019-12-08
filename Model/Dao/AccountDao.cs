using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Utils;

namespace Model.Dao
{
    public class AccountDao
    {
        ShoesStore db = new ShoesStore();

        public bool Login(string username, string password)
        {
            password = EncryptorMD5.Hash(password);
            var quantity = db.Accounts.Count(p => (p.UserName.Equals(username) || p.Email.Equals(username))
            && p.Password.Equals(password));

            return quantity > 0;
        }

        public Account GetAccount(string username)
        {
            if (username == null)
                throw new ArgumentNullException();

            return db.Accounts.SingleOrDefault(p => p.UserName.Equals(username) || p.Email.Equals(username));

        }

        public Account GetByID(long ID)
        {
            return db.Accounts.SingleOrDefault(a => a.AccID == ID);
        }

        public bool ChangePass(long accID, string newPass)
        {
<<<<<<< HEAD
=======
            newPass = EncryptorMD5.Hash(newPass);
>>>>>>> update linh tinh
            try
            {
                var _acc = db.Accounts.Find(accID);
                _acc.Password = newPass;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SignUp(string email, string password)
        {
            try
            {
                var user = db.Users.Add(new User()
                {
                    Email = email
                });
                db.SaveChanges();

                var acc = db.Accounts.Add(new Account()
                {
                    Email = email,
                    Password = password,
                    Status = true,
                    UserID = user.UserID
                    
                });
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
