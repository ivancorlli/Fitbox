
using Domain.src.Entity;
using Domain.src.Enum;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;
using SharedKernell.src.Interface.Command;

namespace Application.src.Features.Profile.Command.CreateUser;

public class CreatePersonHandler : IHandler<CreatePersonCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IPersonManager _PersonManager;

    public CreatePersonHandler(IUnitOfWork unitOfWork, IPersonManager personManager)
    {
        _UnitOfWork = unitOfWork;
        _PersonManager = personManager;
    }

    public async Task<Result> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var name = PersonName.Create(input.name,input.surname);
        if(name.IsFailure)
            return Result.Fail(name.Error);
        var gender = (Gender)Enum.Parse(typeof(Gender),input.gender);
        var newProfile = await _PersonManager.CreatePerson(input.AccountID,name.Value,gender,input.birth);
        if(newProfile.IsFailure)
            return Result.Fail(newProfile.Error);
        await _UnitOfWork.PersonWriteRepository.AddAsync(newProfile.Value);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}