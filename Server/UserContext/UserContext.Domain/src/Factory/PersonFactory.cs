using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Factory;

public class PersonFactory:IAccountFactory
{
    public override Result<Person> CreateAccount(Username username,Email email,string password, Guid? creator)
    {
        var newP =Person.Create(username,email,password);
        if (newP.IsFailure)
            return Result.Fail<Person>(newP.Error);
        return Result.Ok(newP.Value);
    }

}
