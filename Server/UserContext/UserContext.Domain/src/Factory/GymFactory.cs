using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Factory;

public class GymFactory : IAccountFactory
{
    public override Result<IAccount> CreateAccount(Username username, Email email, string password)
    {
        var newGym = Gym.Create(username,email,password);
        if (newGym.IsFailure)
            return Result.Fail<IAccount>(newGym.Error);
        IAccount result = newGym.Value; 
        return Result.Ok(result);
    }
}
