using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticeForMVC.Models;
using PracticeForMVC.Services;

namespace PracticeForMVC.Controllers
{
    [Route("user/")]
    public class UserController : Controller
    {
        private IUserOps _userOps;
        private IMapper _mapper;
        public UserController(IUserOps userOps, IMapper mapper)
        {
            _userOps = userOps ?? throw new ArgumentNullException(nameof(userOps));
            _mapper = mapper;
        }
        [Route("Home")]
        public IActionResult Index()
        {
            ViewBag.message = "Welcome";
            return View();
        }
        [HttpGet("all")]
        public IActionResult GetUsers()
        {
            ViewBag.message = "Welcome";
            var list = _userOps.AllUsers();
            return View(list);
        }
        [HttpPost("add")]
        public IActionResult AddUser([Bind("username", "password")] User user)
        {
            user.Id = new Random().Next();
            _userOps.AddUser(user);
            return RedirectToAction("GetUsers");
        }
        [HttpGet("username/{id}")]
        public ShortUser GetUsername(int id)
        {
            var user = _userOps.GetUserById(id);
            return _mapper.Map<ShortUser>(user);
        }
    }
}
