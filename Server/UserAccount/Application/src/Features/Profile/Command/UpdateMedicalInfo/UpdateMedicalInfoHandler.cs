using Application.src.Errors;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.UpdateMedicalInfo;

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
        var profileFound = await _UnitOfWork.PersonReadRepository.GetById(input.Id);
        var profile = profileFound.Value;
        var medical = profile.Medical;

        if(medical != null)
        {   

            if(input.disabilities != null)
            {
                var newInfo = MedicalInfo.Create(input.disabilities);
                profile.CreateMedicalInfo(newInfo.Value);
                _UnitOfWork.PersonWriteRepository.Update(profile);
                await _UnitOfWork.SaveChangesAsync(cancellationToken);
               
            }
            return Result.Ok();
        }else
        {
            return Result.Fail(new MedicalNotExists());
        }

    }
}