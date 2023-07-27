using Cities.Models;
using Cities.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cities.Controllers
{
    [ApiController]
    [Route("api/city")]
    public class CityController : ControllerBase
    {
        private readonly ImailService _email;
        private readonly ICityOps _cityops;

        public CityController(ImailService email, ICityOps cityops)
        {
            _email = email ?? throw new ArgumentNullException(nameof(_email));
            _cityops = cityops ?? throw new ArgumentNullException(nameof(cityops));
        }


        [HttpGet]
        public IActionResult AllCities() 
        {
            _email.SendEmail();
            return Ok(_cityops.GetAllCities());
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        { 
            var res = _cityops.GetCityById(id);
            if(res == null)
            {
                return NotFound();
            }
            _email.SendEmail();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddCity(City city)
        {
            var res = _cityops.AddCity(city);
            _email.SendEmail();
            return Ok(res);
        }

        [HttpDelete("cityId")]
        public IActionResult DeleteCity(int cityId) 
        {
            var res = _cityops.RemoveCity(cityId);
            if(res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        
    }
}
