using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlazorSkraApp1.Data
{
    public class AccountRepo : IAccount
    {
        private readonly DataContext db;

        public AccountRepo(DataContext _db)
        {
            db = _db;
        }

        public List<Account> GetAllAccounts()
        {
            try
            {
                return db.Accounts.AsNoTracking().ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}