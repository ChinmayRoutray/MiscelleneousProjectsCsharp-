using ActorWebApi.Models;
using ActorWebApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ActorWebApi.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : ControllerBase
    {
        private readonly ICityOps _cityOps;
        private IMapper _mapper;
        public CityController(ICityOps cityOps, IMapper mapper)
        {
            _cityOps = cityOps;
            _mapper = mapper;
        }

        [HttpGet("/all")]
        public IActionResult AllCities()
        {
            return Ok(_cityOps.GetAllCities());
        }

        [HttpGet("all/names")]
        public IActionResult CitiesName() 
        {
            var cities = _cityOps.GetAllCities();
            return Ok(_mapper.Map<IEnumerable<CityName>>(cities));
        }
    }
}
