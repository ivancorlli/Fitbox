using Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.Profile.Command.UpdateMedicalInfo;

public class UpdateMedicalInfoHandler : IHandler<UpdateMedicalInfoCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public UpdateMedicalInfoHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateMedicalInfoCommand request, CancellationToken cancellationToken)
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