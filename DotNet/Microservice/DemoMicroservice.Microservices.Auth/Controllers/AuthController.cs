using DemoMicroservice.Domain.Entity.AuthMicroservice;
using DemoMicroservice.Domain.Interface;
using DemoMicroservice.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoMicroservice.Microservices.Auth.Controllers
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

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = _jwtTokenService.VerifyAndGenerateToken(userCred);
            if (string.IsNullOrEmpty(token))
                return Unauthorized();
            return Ok(new { token });
        }
    }
}
