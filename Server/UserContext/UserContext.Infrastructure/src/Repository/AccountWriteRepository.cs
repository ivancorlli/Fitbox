using Microsoft.EntityFrameworkCore;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.Repository;
using UserContext.Infrastructure.src.Context;

namespace UserContext.Infrastructure.src.Repository
{
    public class AccountWriteRepository : IAccountWriteRepository
    {
        private readonly UserDbContext _AccountContext;
        public AccountWriteRepository(UserDbContext context)
        {
            _AccountContext = context;
        }
        public async Task AddAsync(PersonAccount Entity)
        {
            var newAccount = await _AccountContext.Account.AddAsync(Entity);
        }

        public void Delete(PersonAccount Entity)
        {
            var accountDeleted = _AccountContext.Set<PersonAccount>().Remove(Entity);
        }

        public void Update(PersonAccount entity)
        {
            var accountUpdated = _AccountContext.Account.Update(entity);
        }
    }
}