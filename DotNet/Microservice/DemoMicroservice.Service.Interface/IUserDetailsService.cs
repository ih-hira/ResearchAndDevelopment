using DemoMicroservice.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMicroservice.Service.Interface
{
    public interface IUserDetailsService
    {
        UserDetails GetUserDetailsByUsername(string username);
    }
}
