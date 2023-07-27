using Cities.Models;

namespace Cities.Services
{
    public class CityOps : ICityOps
    {
        private readonly ALLCities _cities = new ALLCities();
        public CityOps(ALLCities cities)
        {
            _cities = cities ?? throw new ArgumentNullException(nameof(cities));
        }
        public List<City> GetAllCities()
        {
            return _cities.cities.OrderBy(c => c.CityName).ToList();
        }

        public City GetCityById(int id)
        {
           return _cities.cities.Where(c => c.CityId == id).FirstOrDefault();
        }

        public ICollection<Interest> GetAllInterests(int id)
        {
            var query = _cities.cities.Where(c => c.CityId == id).FirstOrDefault();
            if(query != null)
            {
                return query.AllInterests;
            }
            return null;
        }

        public Interest GetInterest(int cityId, int interestId)
        {
            var query = _cities.cities.Where(c => c.CityId == cityId).FirstOrDefault();
            if(query != null)
            {
                return query.AllInterests.Where(p => p.InterestId == interestId).FirstOrDefault();
            }
            return null;   
        }

        public City AddInterest(int cityId, Interest interest)
        {
            var query = _cities.cities.Where(c => c.CityId == cityId).FirstOrDefault();
            if(query != null)
            {
                query.AllInterests.Add(interest);
                return query;
            }
            return null;
        }

        public City RemoveInterest(int cityId, int interestId)
        {
            var query = _cities.cities.Where(c => c.CityId == cityId).FirstOrDefault();
            if(query != null)
            {
                var res = query.AllInterests.Where(p => p.InterestId == interestId).FirstOrDefault();
                if(res != null)
                {
                    query.AllInterests.Remove(res);
                    return query;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public ICollection<City> RemoveCity(int cityId)
        {
            var query = _cities.cities.Where(c => c.CityId == cityId).FirstOrDefault();
            if(query != null)
            {
                _cities.cities.Remove(query);
                return _cities.cities;
            }
            return null;
        }

        public City AddCity(City city)
        {
            _cities.cities.Add(city);
            return city;
        }

        public City UpdateInterest(int cityId, int InterestId, Interest inter)
        {
            var query = _cities.cities.Where(c => c.CityId == cityId).FirstOrDefault();
            if(query != null)
            {
                var res = query.AllInterests.Where(p => p.InterestId == InterestId).FirstOrDefault();
                if(res != null)
                {
                    res.Description = inter.Description;
                    return query;
                }
                return null;
            }
            return null;
        }
    }
}
