using Cities.Models;

namespace Cities
{
    public class ALLCities
    {
        public List<City> cities { get; set; }

        public ALLCities()
        {
            Interest I1 = new Interest(1, "Red Fort", 1);
            Interest I2 = new Interest(3, "Parliament", 1);
            Interest I3 = new Interest(4, "Hari Bagicha", 1);
            List<Interest> interests1 = new List<Interest> () { I1, I2, I3 };
            City c1 = new City(1, "Delhi", "Delhi", interests1);

            Interest I11 = new Interest(1, "CSMT Station", 2);
            Interest I12 = new Interest(2, "Airport", 2);
            List<Interest> interests2 = new List<Interest>() { I11, I12 };
            City c2 = new City(2, "Mumbai", "Goregaon", interests2);

            this.cities = new List<City>()  {c1, c2 };
        }
        
    }
}
