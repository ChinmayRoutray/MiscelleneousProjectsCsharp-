using ActorWebApi.Models;
using AutoMapper;

namespace ActorWebApi.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile() 
        {
            CreateMap<City, CityName>();
        }
    }
}
