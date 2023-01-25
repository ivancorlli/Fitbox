﻿using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.Factory;
using UserContext.Domain.src.Repository;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Service;

public class GymManager : AccountManager<IAccount>
{
    public GymManager(IAccountReadRepository<IAccount> repo) : base(repo)
    {
    }

    public override async Task<Result<IAccount>> CreateAccount(Username username, Email email, string password)
    {
        var emailExists = await _AccountRepo.IsEmailInUseAsync(email);
        if (emailExists)
            return Result.Fail<IAccount>(new EmailAlreadyInUse(email.Value.ToString()));
        var usernameExists = await _AccountRepo.IsUsernameInUseAsync(username);
        if (usernameExists)
            return Result.Fail<IAccount>(new UsernameAlreadyInUse(username.Value.ToString()));
        var accountFactory = new PersonFactory();
        var newAccount = accountFactory.CreateAccount(username, email, password, null);
        if (newAccount.IsFailure)
            return Result.Fail<IAccount>(new ValidationError(newAccount.Error.Message));

        return Result.Ok(newAccount.Value);
    }
}
