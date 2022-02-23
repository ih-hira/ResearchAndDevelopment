using DemoMicroservice.Domain.Entity.AuthMicroservice;
using DemoMicroservice.Service.Interface;
using Microsoft.AspNetCore.Mvc;


namespace DemoMicroservice.Microservices.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;
        public AuthController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = _jwtTokenService.VerifyAndGenerateToken(userCred);
            if (string.IsNullOrEmpty(token))
                return Unauthorized();
            return Ok(new { token });
        }
    }
}
