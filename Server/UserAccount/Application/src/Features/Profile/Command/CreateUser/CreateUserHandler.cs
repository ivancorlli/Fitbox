
using Domain.src.Entity;
using Domain.src.Enum;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.CreateUser;

public class CreateUserHandler : IHandler<CreateUserCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public CreateUserHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var name = PersonName.Create(input.name,input.surname);
        if(name.IsFailure)
            return Result.Fail(name.Error);
        var gender = (Gender)Enum.Parse(typeof(Gender),input.gender);
        var newProfile = User.Create(input.AccountID,name.Value,gender,input.birth);
        await _UnitOfWork.UserWriteRepository.AddUser(newProfile.Value);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}