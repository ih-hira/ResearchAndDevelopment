using DemoMicroservice.Domain.Entity;
using DemoMicroservice.Domain.Entity.UserAuth;
using Microsoft.EntityFrameworkCore;

namespace DemoMicroservice.Infrastructure.Repository.DAL
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
    }
}
