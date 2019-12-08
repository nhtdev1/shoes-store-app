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
            if (username == null || password == null) return false;
            if (username.Trim().Equals("") || password.Trim().Equals("")) return false;
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
            newPass = EncryptorMD5.Hash(newPass);
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

        public int SignUp(string email, string password)
        {
            if (email.Trim().Equals("")) return 0;
            if (password.Trim().Equals("")) return 1;
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
                    Password = EncryptorMD5.Hash(password),
                    Status = true,
                    UserID = user.UserID
                    
                });
                db.SaveChanges();
                return 2;
            }
            catch
            {
                return 3;
            }
        }
    }
}
