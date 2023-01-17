using UserContext.Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.Profile.Command.CreatePerson;

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
        var name = PersonName.Create(input.name, input.surname);
        if (name.IsFailure)
            return Result.Fail(name.Error);
        var gender = (Gender)Enum.Parse(typeof(Gender), input.gender);
        var newProfile = await _PersonManager.CreatePerson(input.AccountID, name.Value, gender, input.birth);
        if (newProfile.IsFailure)
            return Result.Fail(newProfile.Error);
        await _UnitOfWork.PersonWriteRepository.AddAsync(newProfile.Value);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}