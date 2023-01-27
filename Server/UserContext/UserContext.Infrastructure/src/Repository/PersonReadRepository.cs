using Microsoft.EntityFrameworkCore;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.Repository;
using UserContext.Domain.src.ValueObject;
using UserContext.Infrastructure.src.Context;

namespace UserContext.Infrastructure.src.Repository;

public class PersonReadRepository : IAccountReadRepository<Person>
{
    private readonly UserDbContext _AccountContext;
    public PersonReadRepository(UserDbContext context)
    {
        _AccountContext = context;
    }

    public async Task<List<Person>> FindByEmailOrUsernameAsync(string access)
    {
        var accountFound = await _AccountContext.Person
                         .Where(ac => ac.Email.Value == access || ac.Username.Value == access)
                         .ToListAsync();

        return accountFound;
    }

    public async Task<Person?> GetByIdAsync(Guid Id)
    {
        var accountFound = await _AccountContext.Person.FindAsync(Id);
        return accountFound;
    }


    public async Task<bool> IsEmailInUseAsync(Email email)
    {
        var response = false;
        var emailExists = await _AccountContext.Person
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
        var emailExists = await _AccountContext.Person
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
        var emailExists = await _AccountContext.Person
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