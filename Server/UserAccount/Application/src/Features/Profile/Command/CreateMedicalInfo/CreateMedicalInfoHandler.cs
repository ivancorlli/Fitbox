using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.CreateMedicalInfo;

public class CreateMedicalInfoHandler:IHandler<CreateMedicalInfoCommand,Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public CreateMedicalInfoHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateMedicalInfoCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var medicalRecord = MedicalInfo.Create(input.disabilities);
        var userFound = await _UnitOfWork.UserReadRepository.GetById(input.Id);
        var user = userFound.Value;
        user.CreateMedicalInfo(medicalRecord.Value);
        Task.WaitAll(
                 _UnitOfWork.UserWriteRepository.Update(user),
                _UnitOfWork.SaveChangesAsync(cancellationToken)
        );
        return Result.Ok();
    }
}