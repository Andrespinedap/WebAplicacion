using Microsoft.AspNetCore.Mvc;
using WebAplicacion.Interfaces;
using WebAplicacion.Model;

namespace WebAplicacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUser()
        {
            var user = _userRepository.GetUsers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }
        [HttpGet("{Userid}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUsers(int Userid)
        {
            if (_userRepository.UserExits(Userid))
                return NotFound();
            var users = _userRepository.GetUser(Userid);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(users);
        }

        [HttpGet("{Userid}/id")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult GetUsersid(int Userid)
        {
            if (!_userRepository.UserExits(Userid))
                return NotFound();

            var id = _userRepository.GetUser(Userid);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(Userid);
        }
    }
}