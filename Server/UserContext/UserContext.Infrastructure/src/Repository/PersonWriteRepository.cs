using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.Repository;
using UserContext.Infrastructure.src.Context;

namespace UserContext.Infrastructure.src.Repository
{
    public class PersonWriteRepository : IAccountWriteRepository<Person>
    {
        private readonly UserDbContext _AccountContext;
        public PersonWriteRepository(UserDbContext context)
        {
            _AccountContext = context;
        }
        public async Task AddAsync(IAccount Entity)
        {
            await _AccountContext.Set<IAccount>().AddAsync(Entity);
        }

        public async Task AddAsync(Person Entity)
        {
            await _AccountContext.Person.AddAsync(Entity);
        }

        public async Task DeleteAsync(Person Entity)
        {
           await _AccountContext.Set<Person>().Remove(Entity).ReloadAsync();
        }

        public async Task UpdateAsync(Person entity)
        {
            await _AccountContext.Set<Person>().Update(entity).ReloadAsync();
        }
        public async Task AddProfileAsync(PersonProfile profile)
        {
            await _AccountContext.PersonProfile.AddAsync(profile);
        }
    }
}