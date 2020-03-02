using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Data
{
    public class AccountService
    {
        private readonly IAccount objAccount;

        public AccountService(IAccount _objAccount)
        {
            objAccount = _objAccount;
        }

        public Task<List<Account>> GetAccountList()
        {
            return Task.FromResult(objAccount.GetAllAccounts());
        }

    }
}