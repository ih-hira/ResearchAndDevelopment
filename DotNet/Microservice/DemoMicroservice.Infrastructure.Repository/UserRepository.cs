using DemoMicroservice.Domain.Entity.UserAuth;
using DemoMicroservice.Domain.Interface;
using DemoMicroservice.Infrastructure.Repository.DAL;
using System;
using System.Linq;

namespace DemoMicroservice.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<UsersDbContext, User>, IUserRepository
    {
        public UserRepository(UsersDbContext context) : base(context)
        {

        }
        public User GetUserByCred(UserCred userCred)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username.Equals(userCred.Username) && u.Password.Equals(userCred.Password));
            if (user != null)
                return user as User;
            return new User();
        }
        public User GetUserByUsername(string userName)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username.Equals(userName));
            if (user != null)
            {
                user.Password = "********";
                return user;
            }

            return new User();
        }
        public User GetUserByUserId(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                user.Password = "********";
                return user;
            }

            return new User();
        }
    }
}
