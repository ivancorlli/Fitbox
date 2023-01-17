using Microsoft.EntityFrameworkCore;
using UserContext.Domain.src.Entity;
using UserContext.Infrastructure.src.Data;

namespace UserContext.Infrastructure.src.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Account => Set<Account>();
        public DbSet<Person> Person => Set<Person>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }

    }
}