using DemoMicroservice.Domain.Entity.AuthMicroservice;
using DemoMicroservice.Domain.Interface;
using DemoMicroservice.Service.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoMicroservice.Service.Implementation
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        public readonly IUserRepository _userRepository;

        private static readonly string secretKey = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        public static readonly SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        private readonly SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        public JwtTokenService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _tokenHandler = new JwtSecurityTokenHandler();
        }
        public string VerifyAndGenerateToken(UserCred userCred)
        {
            var user = _userRepository.GetUserByCred(userCred);
            if (!string.IsNullOrEmpty(user.UserName))
            {
                var Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, userCred.Username),
                    new Claim(ClaimTypes.Role,user.Role)
                };

                SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(Claims),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = credentials
                };
                SecurityToken securityToken = _tokenHandler.CreateToken(securityTokenDescriptor);
                string token = _tokenHandler.WriteToken(securityToken);
                return token;
            }
            return string.Empty;
        }
    }
}
