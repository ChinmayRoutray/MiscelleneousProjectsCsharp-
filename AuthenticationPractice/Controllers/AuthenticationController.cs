using AuthenticationPractice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationPractice.Controllers
{
    [ApiController]
    [Route("api/authenticate/")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticate _auth;
        private readonly ILogger<AuthenticationController> _logger;
        private HttpClient client;
        private Authenticate auth;
        public AuthenticationController(IAuthenticate iauth)
        {
            _auth = iauth ?? throw new ArgumentNullException(nameof(auth));
            //_client = httpClient ?? throw new ArgumentNullException("client"); 
        }

        [HttpPost("user")]
        public IActionResult Verify(string Username, string Password)
        {
            var res = _auth.GetToken(Username, Password);
            if (res == null)
            {
                return Unauthorized("Not Authorized");
            }
            auth.tok = res;
            return Ok(res);
        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult AllUsers()
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + auth.tok);
            return Ok(_auth.GetUsers());

        }

        [HttpGet("{Id}")]
        //[Authorize]
        public IActionResult GetUserById(int Id)
        {
            var res = _auth.GetUserById(Id);
            if (res == null)
            {
                return NotFound("not found");
            }
            return Ok(res);
        }
    }
}