using CitiesDbImplementation.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitiesDbImplementation.Controllers
{
    [ApiController]
    [Route("api/city")]
    public class CityController : ControllerBase
    {
        private readonly ImailService _mailservice;
        private readonly ICityOps _cityops;
        
        public CityController(ImailService mailservice, ICityOps cityops)
        {
            _mailservice = mailservice;
            _cityops = cityops;
        }

        [HttpGet]
        public IActionResult GetAllCities()
        {
            _mailservice.SendMail("List of Cities", "Respective API call was made.");
            return Ok(_cityops.GetAllCities());
        }
    }
}
