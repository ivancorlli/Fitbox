using UserContext.Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.Profile.Command.CreateMedicalInfo;

public class CreateMedicalInfoHandler : IHandler<CreateMedicalInfoCommand, Result>
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
        var personFound = await _UnitOfWork.PersonReadRepository.GetByIdAsync(input.Id);
        if (personFound == null)
            return Result.Fail(new PersonNotExists());
        personFound.CreateMedicalInfo(medicalRecord.Value);

        _UnitOfWork.PersonWriteRepository.Update(personFound);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}