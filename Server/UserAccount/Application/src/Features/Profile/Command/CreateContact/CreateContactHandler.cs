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
        var userFound = await _UnitOfWork.UserReadRepository.GetUserById(input.Id);
        var user = userFound.Value;
        user.CreateContact(name.Value,relationShip,phone.Value);
        Task.WaitAll(
            _UnitOfWork.UserWriteRepository.Update(user),
            _UnitOfWork.SaveChangesAsync(cancellationToken)
        );
        return Result.Ok();

    }
}