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
        if (medicalRecord.IsFailure)
            return Result.Fail(medicalRecord.Error);
        var userFound = await _UnitOfWork.PersonReadRepository.GetById(input.Id);
        var user = userFound.Value;
        user.CreateMedicalInfo(medicalRecord.Value);

        _UnitOfWork.PersonWriteRepository.Update(user);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}