using DemoMicroservice.Domain.Entity;
using DemoMicroservice.Domain.Interface;
using DemoMicroservice.Service.Interface;
using System;

namespace DemoMicroservice.Service.Implementation
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly IUserDetailsRepository _userDetailsRepository;
        public UserDetailsService(IUserDetailsRepository userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }
        public UserDetails GetUserDetailsByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return new UserDetails();
            return _userDetailsRepository.GetUserDetailsByUsername(username);
        }
    }
}
