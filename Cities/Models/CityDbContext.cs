using Microsoft.EntityFrameworkCore;

namespace Cities.Models
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions<CityDbContext> options) : base(options) { }


        public DbSet<Interest> AllInterests { get; set; }
        public DbSet<City> AllCities { get; set; } 

         
    }
}
