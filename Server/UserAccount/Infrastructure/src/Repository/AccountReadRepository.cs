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

    public List<Account> FindByEmailOrUsername(string access)
    {
        var accountFound = _AccountContext.Account
                         .Where(ac => ac.Email.Value == access || ac.Username.Value == access)
                         .ToList();

        return accountFound;
    }

    public Account? GetById(Guid Id)
    {
        var accountFound = _AccountContext.Account.Find(Id);
        return accountFound;
    }


    public bool IsEmailInUse(Email email)
    {
        var response = false;
        var emailExists = _AccountContext.Account
                         .Where(ac => ac.Email == email)
                         .ToList();
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

    public bool IsPhoneInUse(Phone phone)
    {
        var response = false;
        var emailExists = _AccountContext.Account
                          .Where(ac => ac.Phone == phone)
                          .ToList();
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

    public bool IsUsernameInUse(Username username)
    {
        var response = false;
        var emailExists =_AccountContext.Account
                          .Where(ac => ac.Username == username)
                          .ToList();
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