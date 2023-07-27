using Bank_MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_MVC_App.Entity
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

        public DbSet<User> AllUsers { get; set; }
        public DbSet<Transaction> AllTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    UserId = 1,
                    UserName = "Akbar",
                    Password = " ImthegreatAkbar",
                    AccountNumber = "000012345674",
                    AccountBalance = 20000
                }
                );
            modelBuilder.Entity<Transaction>()
                .HasData(
                new Transaction()
                {
                    TransactionId = (new Random()).Next(),
                    Amount = 10000,
                    Benificiary = "Birbal",
                    Date = DateTime.Now,
                    UserId = 1
                }
                );
        }
    }
}
