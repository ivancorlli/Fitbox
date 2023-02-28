using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Factory;

public class PersonFactory:IAccountFactory
{

    internal override Result<IAccount> CreateAccount( Email email)
    {
        var newPerson = Person.Create(email);
        if (newPerson.IsFailure)
            return Result.Fail<IAccount>(newPerson.Error);
        IAccount result = newPerson.Value;
        return Result.Ok(result);
    }

    internal override Result<IAccount> CreateAccount(Username username,Email email,string password)
    {
        var newPerson = Person.Create(username, email, password);
        if (newPerson.IsFailure)
            return Result.Fail<IAccount>(newPerson.Error);
        IAccount result = newPerson.Value;
        return Result.Ok(result);
    }

}
