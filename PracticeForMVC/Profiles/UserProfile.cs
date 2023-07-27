
using AutoMapper;
using PracticeForMVC.Models;

namespace PracticeForMVC.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, ShortUser>();
        }    
    }
}
