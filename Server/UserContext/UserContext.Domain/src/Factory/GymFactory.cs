using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Factory;

public class GymFactory : IAccountFactory
{
    public override Result<IAccount> CreateAccount(Username username, Email email, string password, Guid? creator)
    {
        if (creator == null)
            return Result.Fail<IAccount>(new ValidationError("Es necesariio enviar el id del creador del gimnasio"));
        var newG = Gym.Create(username, email, password,creator.Value);
        if (newG.IsFailure)
            return Result.Fail<IAccount>(newG.Error);
        return Result.Ok<IAccount>(newG.Value);
    }
}
