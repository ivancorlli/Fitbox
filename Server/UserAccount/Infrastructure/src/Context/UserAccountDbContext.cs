using Domain.src.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.src.Context
{
    public class UserAccountDbContext : DbContext
    {
        public UserAccountDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Account> Account => Set<Account>();
        public DbSet<User> User => Set<User>();

    }
}