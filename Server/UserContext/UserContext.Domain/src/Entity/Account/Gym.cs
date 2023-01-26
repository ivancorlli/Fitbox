using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Entity.Account;

public class Gym :IAccount
{
    public GymProfile? GymProfile { get; private set; }

    private Gym(Username username, Email email, Password password):base(username,email,password)
    {
        AccountType = Enum.AccountType.Institutional; 
    }

    internal static Result<Gym> Create(Username username, Email email, string password)
    {
        var validPass = ValidPasswordData(username, email, password);
        if (validPass.IsFailure)
            return Result.Fail<Gym>(new ValidationError(validPass.Error.Message));
        var newPass = Password.Create(password);
        if (newPass.IsFailure)
            return Result.Fail<Gym>(new ValidationError(newPass.Error.Message));
        Gym newAccount = new (username, email, newPass.Value); 
        return Result.Ok(newAccount);
    }
}
