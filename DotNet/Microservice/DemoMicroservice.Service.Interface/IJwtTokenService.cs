using DemoMicroservice.Domain.Entity.AuthMicroservice;

namespace DemoMicroservice.Service.Interface
{
    public interface IJwtTokenService
    {
        public string VerifyAndGenerateToken(UserCred userCred);
    }
}
