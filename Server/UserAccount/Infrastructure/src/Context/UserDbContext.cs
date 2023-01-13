using Domain.src.Entity;
using Infrastructure.src.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.src.Context
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