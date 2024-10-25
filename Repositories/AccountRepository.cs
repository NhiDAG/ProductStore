using BussinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountMember GetAccountById(string accountId)
            => AccountDAO.GetAccountById(accountId);
    }
}
