using DemoMicroservice.Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoMicroservice.Microservices.Users.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(id);

            var user = _userRepository.GetUserByUsername(id);
            if (string.IsNullOrEmpty(user.Id))
                return NotFound("User not found");

            return Ok(user);
        }
    }
}
