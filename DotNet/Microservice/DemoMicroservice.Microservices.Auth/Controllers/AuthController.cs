using DemoMicroservice.Domain.Entity.UserAuth;
using DemoMicroservice.Domain.Interface;
using DemoMicroservice.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DemoMicroservice.Microservices.Users.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _jwtTokenService;
        private readonly IUserRepository _userRepository;
        public AuthController(ITokenService jwtTokenService, IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserCred userCred)
        {
            var user = _userRepository.GetUserByCred(userCred);
            if (string.IsNullOrEmpty(user.Username))
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var accessToken = _jwtTokenService.GenerateAccessToken(claims);
            var refreshToken = _jwtTokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            _userRepository.Update();

            return StatusCode(StatusCodes.Status200OK, new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }
    }
}
