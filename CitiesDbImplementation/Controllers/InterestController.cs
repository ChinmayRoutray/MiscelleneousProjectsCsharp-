using CitiesDbImplementation.Models;
using CitiesDbImplementation.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitiesDbImplementation.Controllers
{
    [ApiController]
    [Route("api/city/{cityId}/interests")]
    public class InterestController : ControllerBase
    {
        private readonly ICityOps _interest;
        private readonly ImailService _email;

        public InterestController(ICityOps interest, ImailService email)
        {
            _interest = interest ?? throw new ArgumentNullException(nameof(interest));
            _email = email ?? throw new ArgumentNullException(nameof(email));
        }

        [HttpGet]
        public IActionResult GetAllInterests(int cityId)
        {
            var res = _interest.GetAllInterests(cityId);
            _email.SendMail("All Interests", "Respective API call was made.");
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddInterest(int cityId, Interest interest) 
        { 
            var res =_interest.AddInterest(cityId, interest);
            if(res == null)
            {
                return NotFound();
            }
            _email.SendMail("Success", "Request Successfully Responded");
            return Ok(res);
        }

        [HttpPut("{interestId}")]
        public IActionResult UpdateInterest(int cityId, int interestId, Interest interest)
        {
            var res = _interest.ModifyInterest(cityId, interestId, interest);
            if (res == null)
            {
                return NotFound();
            }
            _email.SendMail("Success", "Request Successfully Responded");
            return Ok(res);
        }

        [HttpDelete("{interestId}")]
        public IActionResult DeleteInterest(int cityId, int interestId)
        {
            var res = _interest.RemoveInterest(cityId, interestId);
            if(res == null)
            {
                return NotFound();
            }
            _email.SendMail("Success", "Request Successfully Responded");
            return Ok(res);
        }
    }
}
