
using Domain.src.Interface;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.DeleteContact;

public class DeleteContactHandler : IHandler<DeleteContactCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public DeleteContactHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var profileFound = await _UnitOfWork.PersonReadRepository.GetById(input.Id);
        var profile = profileFound.Value;
        profile.DeleteContact();
        _UnitOfWork.PersonWriteRepository.Update(profile);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}