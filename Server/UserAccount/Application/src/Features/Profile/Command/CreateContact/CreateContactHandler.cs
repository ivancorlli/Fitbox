using Domain.src.Enum;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.CreateContact;

public class CreateContactHandler : IHandler<CreateContactCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork ;

    public CreateContactHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input; 
        var name = PersonName.Create(input.name,input.surname);
        if(name.IsFailure)
            return Result.Fail(name.Error);
        var relationShip = (RelationShip)Enum.Parse(typeof(RelationShip),input.relationship);
        var phone = ContactPhone.Create(input.areaCode,input.number);
        if(phone.IsFailure)
            return Result.Fail(phone.Error);
        var personFound = await _UnitOfWork.PersonReadRepository.GetById(input.Id);
        var person= personFound.Value;
        person.CreateContact(name.Value,relationShip,phone.Value);

        _UnitOfWork.PersonWriteRepository.Update(person);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok();

    }
}