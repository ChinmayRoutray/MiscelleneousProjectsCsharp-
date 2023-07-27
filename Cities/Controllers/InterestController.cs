using Cities.Models;
using Cities.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Cities.Controllers
{
    [ApiController]
    [Route("api/city/{cityId}/Interests")]
    public class InterestController : ControllerBase
    {
        private readonly ICityOps _cityops;
        private readonly ImailService _email;

        public InterestController(ICityOps cityops, ImailService mailservice)
        {
            _cityops = cityops ?? throw new ArgumentNullException(nameof(cityops));
            _email = mailservice ?? throw new ArgumentNullException(nameof(mailservice));
        }

        [HttpGet]
        public IActionResult GetAllInterestForCity(int cityId)
        {
            var res = _cityops.GetAllInterests(cityId);
            if (res == null)
            {
                return NotFound();
            }
            _email.SendEmail();
            return Ok(res);
        }

        [HttpGet("{interestId}")]
        public IActionResult GetInterest(int cityId, int interestId)
        {
            var res = _cityops.GetInterest(cityId, interestId);
            if (res == null)
            {
                return NotFound();
            }
            _email.SendEmail();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddInterest(int cityId, Interest interest)
        {
            var res = _cityops.AddInterest(cityId, interest);
            if(res != null)
            {
                _email.SendEmail();
                return Ok(res);
            }
            return NotFound();
        }

        [HttpPut("{interestId}")]
        public IActionResult UpdateInterestInCity(int cityId, int interestId, Interest inter)
        {
            var res = _cityops.UpdateInterest(cityId,interestId, inter);
            if(res == null)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{interestId}")]
        public IActionResult DeleteInterest(int cityId, int interestId)
        {
            var res = _cityops.RemoveInterest(cityId, interestId);
            if (res == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
