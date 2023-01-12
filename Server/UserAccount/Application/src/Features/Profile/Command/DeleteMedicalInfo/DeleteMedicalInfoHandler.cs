using Domain.src.Interface;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.DeleteMedicalInfo;

public class DeleteMedicalInfoHandler : IHandler<DeleteMedicalInfoCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public DeleteMedicalInfoHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteMedicalInfoCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var profileFound = await _UnitOfWork.PersonReadRepository.GetById(input.Id);
        var profile = profileFound.Value;
        profile.DeleteMedicalInfo();
        _UnitOfWork.PersonWriteRepository.Update(profile);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}