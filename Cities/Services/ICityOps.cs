using Cities.Models;

namespace Cities.Services
{
    public interface ICityOps
    {
        List<City> GetAllCities();
        City GetCityById(int id);
        ICollection<Interest> GetAllInterests(int cityId);
        Interest GetInterest(int cityId, int interestID);
        City AddInterest(int cityId, Interest interest);
        City AddCity(City city);
        City UpdateInterest(int cityId, int InterestId, Interest inter);
        ICollection<City> RemoveCity(int cityId);
        City RemoveInterest(int cityId, int interestID);
    }
}
