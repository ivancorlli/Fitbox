using Microsoft.EntityFrameworkCore;
using UserContext.Domain.src.Abstractions;
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

        public DbSet<IAccount> Account => Set<IAccount>();
        public DbSet<Person> Person => Set<Person>(); 
        public DbSet<PersonProfile> PersonProfile => Set<PersonProfile>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IAccount>()
                .ToTable("Account")
                .HasDiscriminator<string>("UserType")
                .HasValue<Person>("Person");
            modelBuilder.ApplyConfiguration(new PersonAccountConfiguration());
            modelBuilder.ApplyConfiguration(new PersonProfileConfiguration());
        }

    }
}