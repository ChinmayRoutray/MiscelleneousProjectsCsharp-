using ActorWebApi.Models;

namespace ActorWebApi.Services
{
    public interface ICityOps
    {
        IEnumerable<City> GetAllCities();
    }
}
