using UserContext.Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.Account.Command.CreateContact;

public class ChangeContactHandler : IHandler<ChangeContactCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public ChangeContactHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ChangeContactCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var name = PersonName.Create(input.name, input.surname);
        if (name.IsFailure)
            return Result.Fail(name.Error);
        var relationShip = (RelationShip)Enum.Parse(typeof(RelationShip), input.relationship);
        var phone = ContactPhone.Create(input.areaCode, input.number);
        if (phone.IsFailure)
            return Result.Fail(phone.Error);
        var account = await _UnitOfWork.AccountReadRepository.GetByIdAsync(input.Id);
        if (account == null)
            return Result.Fail(new AccountNotExists());
        if (account.Profile == null)
            return Result.Fail(new ProfileNotExists());

        account.Profile.CreateContact(name.Value, relationShip, phone.Value);

        _UnitOfWork.AccountWriteRepository.Update(account);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();

    }
}