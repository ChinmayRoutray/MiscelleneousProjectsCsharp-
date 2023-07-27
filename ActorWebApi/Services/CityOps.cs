using ActorWebApi.Models;

namespace ActorWebApi.Services
{
    public class CityOps : ICityOps
    {
        private readonly SakilaContext _context;
        public CityOps(SakilaContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetAllCities() 
        {
            return _context.Cities.ToList();
        }
    }
}
