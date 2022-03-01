using DemoMicroservice.Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoMicroservice.Microservices.Users.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("UserDetails")]
        public IActionResult Details(string username)
        {
            if (string.IsNullOrEmpty(username))
                return BadRequest(username);

            var user = _userRepository.GetUserByUsername(username);
            if (string.IsNullOrEmpty(user.Username))
                return NotFound("User not found");

            return Ok(user);
        }
    }
}
