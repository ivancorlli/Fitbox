using Domain.src.Entity;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Infrastructure.src.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.src.Repository;

public class AccountReadRepository : IAccountReadRepository
{
    private readonly UserDbContext _AccountContext; 
    public AccountReadRepository(UserDbContext context)
    {   
        _AccountContext = context;
    }

    public async Task<List<Account>> FindByEmailOrUsernameAsync(string access)
    {
        var accountFound = await _AccountContext.Account
                         .Where(ac => ac.Email.Value == access || ac.Username.Value == access)
                         .ToListAsync();

        return accountFound;
    }

    public async Task<Account?> GetByIdAsync(Guid Id)
    {
        var accountFound = await _AccountContext.Account.FindAsync(Id);
        return accountFound;
    }


    public async Task<bool> IsEmailInUseAsync(Email email)
    {
        var response = false;
        var emailExists = await _AccountContext.Account
                         .Where(ac => ac.Email == email)
                         .ToListAsync();
        if(emailExists.Count > 0)
        {
            response = true;
        }
        else
        {
            response = false;
        }
        return response;
    }

    public async Task<bool> IsPhoneInUseAsync(Phone phone)
    {
        var response = false;
        var emailExists = await _AccountContext.Account
                          .Where(ac => ac.Phone == phone)
                          .ToListAsync();
        if (emailExists.Count > 0)
        {
            response = true;
        }
        else
        {
            response = false;
        }
        return response;
    }

    public async Task<bool> IsUsernameInUseAsync(Username username)
    {
        var response = false;
        var emailExists =   await _AccountContext.Account
                          .Where(ac => ac.Username == username)
                          .ToListAsync();
        if (emailExists.Count > 0)
        {
            response = true;
        }
        else
        {
            response = false;
        }
        return response;
    }
}