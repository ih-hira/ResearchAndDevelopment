using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDataSync
{
    public interface IUserRepository
    {
        void AddUser(UserInfo user);
        List<UserInfo> GetAllUsers();
        void DeleteUser(UserInfo user);
        void UpdateUser(UserInfo user);
    }
}
