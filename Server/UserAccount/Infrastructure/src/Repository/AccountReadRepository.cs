using Domain.src.Entity;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Infrastructure.src.Context;
using Infrastructure.src.Error;
using Shared.src.Error;

namespace Infrastructure.src.Repository;

public class AccountReadRepository : IAccountReadRepository
{
    private readonly UserAccountDbContext _AccountContext; 
    public AccountReadRepository(UserAccountDbContext context)
    {   
        _AccountContext = context;
    }

    public Task<Result<Account>> FindByEmailOrUsername(string access)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Account>> GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Account>> GetUserById(Guid Id)
    {
        var userFound = await _AccountContext.Set<Account>().FindAsync(Id);
        if(userFound == null)
            return Result.Fail<Account>(new UserNotFound());

        return Result.Ok<Account>(userFound);
    }

    public Task<bool> IsEmailInUse(Email email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsPhoneInUse(Phone phone)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsUsernameInUse(Username username)
    {
        throw new NotImplementedException();
    }

}