using Domain.src.Entity;
using Infrastructure.src.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Infrastructure.src.Context
{
    public class UserAccountDbContext : DbContext
    {
        public UserAccountDbContext(DbContextOptions options) : base(options)
        {
        }
        
        // public DbSet<Account> Account => Set<Account>();
        public DbSet<User> User => Set<User>();

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
         }

    }
}