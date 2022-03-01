using DemoMicroservice.Domain.Entity;
using DemoMicroservice.Domain.Interface;
using DemoMicroservice.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMicroservice.Microservices.Users.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _jwtTokenService;
        private readonly IUserRepository _userRepository;
        public TokenController(ITokenService jwtTokenService, IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;

        }
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] NewTokenRequest tokenRequest)
        {
            if (tokenRequest is null)
            {
                return BadRequest("Invalid client request");
            }
            string accessToken = tokenRequest.AccessToken;
            string refreshToken = tokenRequest.RefreshToken;

            var principal = _jwtTokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;

            var user = _userRepository.GetUserByUsername(username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid client request");
            }
            var newAccessToken = _jwtTokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _jwtTokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7); ;
            _userRepository.Update();

            return Ok(new
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }
        [HttpPost("revoke"), Authorize]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var user = _userRepository.GetUserByUsername(username);
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;
            if (user == null) return BadRequest();
            _userRepository.Update();
            return NoContent();
        }
    }
}
