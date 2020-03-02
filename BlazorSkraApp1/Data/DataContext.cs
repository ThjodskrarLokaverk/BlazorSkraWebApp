using System;
using Microsoft.EntityFrameworkCore;

namespace BlazorSkraApp1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=tcp:thjodskradbserver.database.windows.net,1433;Initial Catalog=BlazorSkraApp1_db;Persist Security Info=False;User ID=benedikt17;Password=Qwerty&123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}