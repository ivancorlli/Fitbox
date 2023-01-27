using UserContext.Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;
using UserContext.Domain.src.Entity.Account;

namespace UserContext.Application.src.Features.PersonAccount.Command.ChangeUsername;

public class ChangeUsernameHandler : IHandler<ChangeUsernameCommand, Result>
{
    private readonly IAccountManager<Person> _AccountManager;
    private readonly IUnitOfWork _UnitOfWork;

    public ChangeUsernameHandler(IAccountManager<Person> manager, IUnitOfWork unitOfWork)
    {
        _AccountManager = manager;
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ChangeUsernameCommand request, CancellationToken cancellationToken)
    {
        var input = request.input;
        var username = Username.Create(input.username);
        if (username.IsFailure)
            return Result.Fail(username.Error);
        var accountExist = await _UnitOfWork.PersonReadRepository.GetByIdAsync(input.id);
        if (accountExist == null)
            return Result.Fail(new AccountNotExists());
        var usernameChanged = await _AccountManager.ChangeUsername(accountExist, username.Value);
        if (usernameChanged.IsFailure)
            return Result.Fail(usernameChanged.Error);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}