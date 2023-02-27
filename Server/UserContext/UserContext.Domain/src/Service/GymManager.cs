using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.Factory;
using UserContext.Domain.src.Repository;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Service;

public class GymManager : AccountManager<Gym>
{
    public GymManager(IAccountReadRepository<Gym> repo) : base(repo)
    {
    }


    public override async Task<Result<IAccount>> CreateAccount(Email email)
    {
        var emailExists = await _AccountRepo.IsEmailInUseAsync(email);
        if (emailExists)
            return Result.Fail<IAccount>(new EmailAlreadyInUse(email.Value.ToString()));
        var accountFactory = new GymFactory();
        var newAccount = accountFactory.CreateAccount(email);
        if (newAccount.IsFailure)
            return Result.Fail<IAccount>(new ValidationError(newAccount.Error.Message));
        IAccount result = newAccount.Value;
        return Result.Ok(result);
    }

    public override async Task<Result<IAccount>> CreateAccount(Username username, Email email, string password)
    {
        var emailExists = await _AccountRepo.IsEmailInUseAsync(email);
        if (emailExists)
            return Result.Fail<IAccount>(new EmailAlreadyInUse(email.Value.ToString()));
        var usernameExists = await _AccountRepo.IsUsernameInUseAsync(username);
        if (usernameExists)
            return Result.Fail<IAccount>(new UsernameAlreadyInUse(username.Value.ToString()));
        var accountFactory = new GymFactory();
        var newAccount = accountFactory.CreateAccount(username, email, password);
        if (newAccount.IsFailure)
            return Result.Fail<IAccount>(new ValidationError(newAccount.Error.Message));
        IAccount result = newAccount.Value;
        return Result.Ok(result);
    }
}
