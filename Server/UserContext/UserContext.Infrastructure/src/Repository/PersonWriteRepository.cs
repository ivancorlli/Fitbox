using Microsoft.EntityFrameworkCore;
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
        public async Task AddAsync(Person Entity)
        {
            var newAccount = await _AccountContext.Account.AddAsync(Entity);
        }

        public void Delete(Person Entity)
        {
            var accountDeleted = _AccountContext.Set<Person>().Remove(Entity);
        }

        public void Update(Person entity)
        {
            var accountUpdated = _AccountContext.Account.Update(entity);
        }
    }
}