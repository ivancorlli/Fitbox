using UserContext.Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.Account.Command.ChangeMedicalInfo;

public class ChangeMedicalInfoHandler : IHandler<ChangeMedicalInfoCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public ChangeMedicalInfoHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ChangeMedicalInfoCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var medicalRecord = MedicalInfo.Create(input.disabilities);
        if (medicalRecord.IsFailure)
            return Result.Fail(medicalRecord.Error);
        var account = await _UnitOfWork.AccountReadRepository.GetByIdAsync(input.Id);
        if (account == null)
            return Result.Fail(new AccountNotExists());
        if(account.Profile == null)
            return Result.Fail(new ProfileNotExists());
        account.Profile.CreateMedicalInfo(medicalRecord.Value);

        _UnitOfWork.AccountWriteRepository.Update(account);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}