using DemoMicroservice.Domain.Entity.UserAuth;

namespace DemoMicroservice.Domain.Interface
{
    public interface IUserRepository: IBaseRepository<User>
    {
        public User GetUserByCred(UserCred userCred);
        public User GetUserByUsername(string username);
        public User GetUserByUserId(int id);
    }
}
