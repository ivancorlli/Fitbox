using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Errors;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.Account.Command.ChangeProfile;

public class ChangeProfileHandler : IHandler<ChangeProfileCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public ChangeProfileHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ChangeProfileCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var name = PersonName.Create(input.name, input.surname);
        if (name.IsFailure)
            return Result.Fail(name.Error);
        var gender = (Gender)Enum.Parse(typeof(Gender), input.gender);
        var account = await _UnitOfWork.AccountReadRepository.GetByIdAsync(input.id);
        if (account == null)
            return Result.Fail(new AccountNotExists());
        var newProfile = account.AddProfile(name.Value, gender,input.birth);
        if (newProfile.IsFailure)
            return Result.Fail(newProfile.Error);
        _UnitOfWork.AccountWriteRepository.Update(account);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}