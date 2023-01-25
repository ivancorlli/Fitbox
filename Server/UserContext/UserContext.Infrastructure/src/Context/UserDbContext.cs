using Microsoft.EntityFrameworkCore;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.Entity.Account;
using UserContext.Infrastructure.src.Data;

namespace UserContext.Infrastructure.src.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Account => Set<Person>();
        public DbSet<PersonProfile> Person => Set<PersonProfile>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }

    }
}