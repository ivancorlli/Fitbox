using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.PersonAccount.Command.CreateAccount;

internal class CreateAccountHandler : IHandler<CreateAccountCommand, Result>
{
    private readonly IAccountManager<Person> _AccountManager;
    private readonly IUnitOfWork _Unit;

    public CreateAccountHandler(IAccountManager<Person> accountManager, IUnitOfWork unit)
    {
        _AccountManager = accountManager;
        _Unit = unit;
    }

    public async Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var username = Username.Create(input.Username);
        if (username.IsFailure)
            return Result.Fail(username.Error);
        var email = Email.Create(input.Email);
        if (email.IsFailure)
            return Result.Fail(email.Error);
        var person = await _AccountManager.CreateAccount(username.Value, email.Value, input.Password);
        if(person.IsFailure)
            return Result.Fail(person.Error);
        await _Unit.PersonWriteRepository.AddAsync(person.Value);
        await _Unit.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
