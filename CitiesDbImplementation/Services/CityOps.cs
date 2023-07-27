using CitiesDbImplementation.Entity;
using CitiesDbImplementation.Models;

namespace CitiesDbImplementation.Services
{
    public class CityOps : ICityOps 
    {
        private readonly CityDbContext _context;

        public CityOps(CityDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ICollection<City> GetAllCities()
        {
            return _context.AllCities.ToList();
        }

        public ICollection<Interest> GetAllInterests(int id)
        {
            var res = _context.AllInterests.Where(c => c.CityId == id).ToList();
            if(res.Count == 0)
            {
                return null;
            }
            return res;
        }
        public Interest AddInterest(int cityId, Interest inter)
        {
            var res = _context.AllCities.Where(c => c.CityId == cityId).FirstOrDefault();
            if(res != null)
            {
                _context.AllInterests.Add(inter);
                _context.SaveChanges();
                return inter;
            }
            return null;
        }

        public Interest ModifyInterest(int cityId, int id, Interest inter)
        {
            var res = _context.AllCities.Where(c => c.CityId == cityId).FirstOrDefault();
            if(res == null)
            {
                return null;
            }
            var query = _context.AllInterests.Where(p => p.InterestId == id).FirstOrDefault();
            if(query == null)
            {
                return null;
            }
            query.Description = inter.Description;
            _context.SaveChanges();
            return query;
        }

        public Interest RemoveInterest(int cityId, int interestId)
        {
            var res = _context.AllCities.Where(c => c.CityId == cityId).FirstOrDefault();
            if(res == null)
            {
                return null;
            }
            var query = _context.AllInterests.Where(p => p.InterestId == interestId).FirstOrDefault();
            if(query == null)
            {
                return null;
            }
            _context.AllInterests.Remove(query);
            _context.SaveChanges();
            return query;
        }
    }
}
