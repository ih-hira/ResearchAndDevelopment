using DemoMicroservice.Domain.Entity.AuthMicroservice;

namespace DemoMicroservice.Domain.Interface
{
    public interface IUserRepository
    {
        public User GetUserByCred(UserCred userCred);
    }
}
