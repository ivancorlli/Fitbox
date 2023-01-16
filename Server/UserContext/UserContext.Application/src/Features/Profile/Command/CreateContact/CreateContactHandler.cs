using Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.Profile.Command.CreateContact;

public class CreateContactHandler : IHandler<CreateContactCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public CreateContactHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var name = PersonName.Create(input.name, input.surname);
        if (name.IsFailure)
            return Result.Fail(name.Error);
        var relationShip = (RelationShip)Enum.Parse(typeof(RelationShip), input.relationship);
        var phone = ContactPhone.Create(input.areaCode, input.number);
        if (phone.IsFailure)
            return Result.Fail(phone.Error);
        var personFound = await _UnitOfWork.PersonReadRepository.GetByIdAsync(input.Id);
        if (personFound == null)
            return Result.Fail(new PersonNotExists());
        personFound.CreateContact(name.Value, relationShip, phone.Value);

        _UnitOfWork.PersonWriteRepository.Update(personFound);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();

    }
}