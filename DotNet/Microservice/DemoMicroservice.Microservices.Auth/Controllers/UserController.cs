using DemoMicroservice.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoMicroservice.Microservices.Users.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserDetailsService _userDetailsService;
        public UserController(IUserDetailsService userDetailsService)
        {
            _userDetailsService = userDetailsService;
        }
        [HttpGet("{username}")]
        public IActionResult UserDetails(string username)
        {
            if (string.IsNullOrEmpty(username))
                return BadRequest(username);

            var user = _userDetailsService.GetUserDetailsByUsername(username);
            if (string.IsNullOrEmpty(user.Username))
                return NotFound("User not found");

            return Ok(user);
        }
    }
}
