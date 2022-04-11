using DemoMicroservice.Domain.Entity;

namespace DemoMicroservice.Domain.Interface
{
    public interface IUserDetailsRepository : IBaseRepository<UserDetails>
    {
        UserDetails GetUserDetailsByUsername(string username);
    }
}
