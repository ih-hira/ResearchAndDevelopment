using DemoMicroservice.Domain.Entity;
using DemoMicroservice.Domain.Entity.UserAuth;
using DemoMicroservice.Domain.Interface;
using DemoMicroservice.Infrastructure.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMicroservice.Infrastructure.Repository
{
    public class UserDetailsRepository : BaseRepository<UsersDbContext, UserDetails>, IUserDetailsRepository
    {
        public UserDetailsRepository(UsersDbContext context) : base(context)
        {

        }
        public UserDetails GetUserDetailsByUsername(string username)
        {
            var userDetails = _context.UserDetails.FirstOrDefault(u => u.Username.Equals(username));
            if (userDetails != null)
            {
                return userDetails;
            }

            return new UserDetails();
        }
    }
}
