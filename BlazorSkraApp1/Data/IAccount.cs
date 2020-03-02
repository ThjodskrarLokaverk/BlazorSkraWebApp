using System.Collections.Generic;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Data
{
    public interface IAccount
    {
        public List<Account> GetAllAccounts();
    }
}