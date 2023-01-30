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
        public DbSet<Gym> Gym=> Set<Gym>();
        public DbSet<PersonProfile> PersonProfile => Set<PersonProfile>();
        public DbSet<GymProfile> GymProfile => Set<GymProfile>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IAccount>().HasDiscriminator<string>("Class");
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new GymProfileConfiguration());
            modelBuilder.ApplyConfiguration(new PersonProfileConfiguration());
        }

    }
}