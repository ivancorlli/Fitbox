using UserContext.Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.Profile.Command.ChangeMedicalInfo;

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
        var personFound = await _UnitOfWork.PersonReadRepository.GetByIdAsync(input.Id);
        if (personFound == null)
            return Result.Fail(new PersonNotExists());
        var medical = personFound.Medical;

        if (medical != null)
        {

            if (input.disabilities != null)
            {
                var newInfo = MedicalInfo.Create(input.disabilities);
                personFound.CreateMedicalInfo(newInfo.Value);
                _UnitOfWork.PersonWriteRepository.Update(personFound);
                await _UnitOfWork.SaveChangesAsync(cancellationToken);

            }
            return Result.Ok();
        }
        else
        {
            return Result.Fail(new MedicalNotExists());
        }

    }
}