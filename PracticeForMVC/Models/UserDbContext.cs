using Microsoft.EntityFrameworkCore;

namespace PracticeForMVC.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<User> UserLoginFormat { get; set; }
    }
}
