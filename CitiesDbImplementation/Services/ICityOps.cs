using CitiesDbImplementation.Models;

namespace CitiesDbImplementation.Services
{
    public interface ICityOps
    {
        ICollection<City> GetAllCities();
        ICollection<Interest> GetAllInterests(int cityId);
        Interest AddInterest(int cityId, Interest inter);
        Interest ModifyInterest(int cityId, int id, Interest inter);
        Interest RemoveInterest(int cityId, int interestId);
    }
}
