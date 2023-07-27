using CitiesDbImplementation.Models;
using Microsoft.EntityFrameworkCore;

namespace CitiesDbImplementation.Entity
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions<CityDbContext> options) : base(options) { }

        public DbSet<City> AllCities { get; set; }

        public DbSet<Interest> AllInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().
                HasData(
                new City()
                {
                    CityName = "Delhi",
                    CityId = 1,
                    CityCapital = "Delhi",
                    /*Interests = new List<Interest>()
                    {
                        new Interest() { InterestId = 1, Description = "Red Fort", CityId = 1 },
                        new Interest() { InterestId = 2, Description = "India Gate", CityId = 1 },
                        new Interest() { InterestId = 3, Description = "Qutub Minar", CityId = 1 }
                    }*/
                },
                new City()
                {
                    CityId = 2,
                    CityName = "Mumbai",
                    CityCapital = "Goregaon"
                },
                new City()
                {
                    CityId = 4,
                    CityName = "Bhubaneswar",
                    CityCapital = "Rasulgarh"
                }) ;
            modelBuilder.Entity<Interest>().
                HasData(
                new Interest() { InterestId = 1, Description = "Red Fort", CityId = 1 },
                new Interest() { InterestId = 2, Description = "India Gate", CityId = 1 },
                new Interest() { InterestId = 3, Description = "Qutub Minar", CityId = 1 },

                new Interest() { InterestId = 4, Description = "Aksa Beach", CityId = 2 },
                new Interest() { InterestId = 5, Description = "Dana Pani Beach", CityId = 2 },
                new Interest() { InterestId = 6, Description = "CSMT", CityId = 2 },

                new Interest() { InterestId = 7, Description = "Planetorium", CityId = 4 },
                new Interest() { InterestId = 8, Description = "Science Park", CityId = 4 },
                new Interest() { InterestId = 9, Description = "Dhauli Giri", CityId = 4 });

            base.OnModelCreating(modelBuilder);
        }
            
        }

        
}

