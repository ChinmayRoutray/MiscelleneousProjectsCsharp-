using Bank_MVC_App.Models;
using Bank_MVC_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Bank_MVC_App.Controllers
{
    [Route("Axis/user/")]
    public class UserController : Controller
    {

        private readonly IUserOps _userops;

        public UserController(IUserOps userOps) 
        {
            _userops = userOps;
        }

        [HttpGet("all")]
        public IActionResult GetUsers()
        {
            ViewBag.message = "Axis Bank ";
            return View(_userops.GetAllUsers());
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var res = _userops.GetUserById(userId);
            if(res == null)
            {
                return NotFound();
            }
            return View(res);
        }

        [HttpGet("Register")]
        public IActionResult SignUp()
        {
            ViewBag.message = "Welcome to Axis Bank !!! Thank you for choosing us.";
            return View(new User()); 
        }

        [HttpPost("process")]
        public IActionResult AddUser([Bind("UserId", "UserName", "Password", "AccountNumber",
            "AccountBalance")] User newUser)
        {
            _userops.AddUser(newUser);
            return RedirectToAction("GetUsers");
            //return StatusCode(201, "created");
        }

        [HttpPut("update/{userId}")]
        public IActionResult ModifyUser(int userId, User updatedUser) 
        {
            if(_userops.UpdateUser(userId, updatedUser) == null)
            {
                return NotFound();
            }
            RedirectToAction("GetUserById(userId)");
            return Ok();
        } 

        [HttpDelete("delete/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            if (_userops.DeleteUser(userId) == null)
            {
                return NoContent();
            }
            RedirectToAction("GetUsers");
            return Ok();
        }
    }
}
