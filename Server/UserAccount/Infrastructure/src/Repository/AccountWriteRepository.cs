using Domain.src.Entity;
using Domain.src.Interface;
using Infrastructure.src.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.src.Repository
{
    public class AccountWriteRepository : IAccountWriteRepository
    {
    private readonly UserDbContext _AccountContext; 
    public AccountWriteRepository(UserDbContext context)
    {   
        _AccountContext = context;
    }
        public async Task AddAsync(Account Entity)
        {
            var newAccount =await _AccountContext.Account.AddAsync(Entity);
        }

        public  void Delete(Account Entity)
        {
            var accountDeleted =  _AccountContext.Set<Account>().Remove(Entity);
        }

        public void Update(Account entity)
        {
            var accountUpdated = _AccountContext.Account.Update(entity);
        }
    }
}