using DemoMicroservice.Domain.Entity.AuthMicroservice;
using DemoMicroservice.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoMicroservice.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;
        public UserRepository()
        {
            _users = new List<User>();
            _users.Add(new User
            {
                Name = "name1",
                UserName = "username1",
                Password = "password1",
                Role="user"
            });
            _users.Add(new User
            {
                Name = "name2",
                UserName = "username2",
                Password = "password2",
                Role="admin"
            });
        }
        public User GetUserByCred(UserCred userCred)
        {
            var user = _users.FirstOrDefault(u => u.UserName.Equals(userCred?.Username) && u.Password.Equals(userCred?.Password));
            if (user != null)
                return user;
            return new User();
        }
    }
}
