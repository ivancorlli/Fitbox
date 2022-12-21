using Domain.src.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.src.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<User> User => Set<User>();

    }
}