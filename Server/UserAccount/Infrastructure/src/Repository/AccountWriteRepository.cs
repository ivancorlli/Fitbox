using Domain.src.Entity;
using Domain.src.Interface;
using Infrastructure.src.Context;

namespace Infrastructure.src.Repository
{
    public class AccountWriteRepository : IAccountWriteRepository
    {
    private readonly UserAccountDbContext _AccountContext; 
    public AccountWriteRepository(UserAccountDbContext context)
    {   
        _AccountContext = context;
    }
        public Task AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task Update(Account account)
        {
            throw new NotImplementedException();
        }
    }
}