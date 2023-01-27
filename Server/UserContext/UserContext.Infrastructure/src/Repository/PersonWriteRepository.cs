using UserContext.Domain.src.Abstractions;
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

        public void Delete(Person Entity)
        {
            _AccountContext.Set<Person>().Remove(Entity);
        }

        public void Update(Person entity)
        {
            _AccountContext.Person.Update(entity);
        }
    }
}