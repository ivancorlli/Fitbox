using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Factory;

public class PersonFactory:IAccountFactory
{
    public override Result<IAccount> CreateAccount(Username username,Email email,string password)
    {
        var newPerson = Person.Create(username, email, password);
        if (newPerson.IsFailure)
            return Result.Fail<IAccount>(newPerson.Error);
        IAccount result = newPerson.Value;
        return Result.Ok(result);
    }

}
