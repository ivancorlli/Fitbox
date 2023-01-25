using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.Event;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Entity.Account;

public class Gym : IAccount
{
    private Gym() { }
    public Guid GymCreator { get; init;}
    public GymProfile? GymProfile { get; private set; }
    private Gym(Username username, Email email, Password password,Guid creator) : base(username, email, password)
    {
        AccountType = Enum.AccountType.Institutional; 
        GymCreator= creator;
    }

    internal static Result<Gym> Create(Username username, Email email, string password, Guid creator)
    {
        var validPass = ValidPasswordData(username, email, password);
        if (validPass.IsFailure)
            return Result.Fail<Gym>(new ValidationError(validPass.Error.Message));
        var newPass = Password.Create(password);
        if (newPass.IsFailure)
            return Result.Fail<Gym>(new ValidationError(newPass.Error.Message));
        var newAccount = new Gym(username, email, newPass.Value,creator);
        newAccount.RaiseDomainEvent(new AccountCreated());
        return Result.Ok(newAccount);
    }
}
