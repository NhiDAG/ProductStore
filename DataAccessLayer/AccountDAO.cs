using BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.ProductStoreContext;

namespace DataAccessLayer
{
    public class AccountDAO
    {
        public static AccountMember GetAccountById(string accountId)
        {
            using var db = new ProductStore();
            return db.Accounts.FirstOrDefault(c => c.MemberId.Equals(accountId));
        }
    }
}
