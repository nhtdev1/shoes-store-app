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
    }
}
