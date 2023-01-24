using Microsoft.EntityFrameworkCore;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.Repository;
using UserContext.Domain.src.ValueObject;
using UserContext.Infrastructure.src.Context;

namespace UserContext.Infrastructure.src.Repository;

public class AccountReadRepository : IAccountReadRepository
{
    private readonly UserDbContext _AccountContext;
    public AccountReadRepository(UserDbContext context)
    {
        _AccountContext = context;
    }

    public async Task<List<PersonAccount>> FindByEmailOrUsernameAsync(string access)
    {
        var accountFound = await _AccountContext.Account
                         .Where(ac => ac.Email.Value == access || ac.Username.Value == access)
                         .ToListAsync();

        return accountFound;
    }

    public async Task<PersonAccount?> GetByIdAsync(Guid Id)
    {
        var accountFound = await _AccountContext.Account.FindAsync(Id);
        return accountFound;
    }


    public async Task<bool> IsEmailInUseAsync(Email email)
    {
        var response = false;
        var emailExists = await _AccountContext.Account
                         .Where(ac => ac.Email.Value == email.Value)
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
        var emailExists = await _AccountContext.Account
                          .Where(ac => ac.Username.Value ==username.Value)
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