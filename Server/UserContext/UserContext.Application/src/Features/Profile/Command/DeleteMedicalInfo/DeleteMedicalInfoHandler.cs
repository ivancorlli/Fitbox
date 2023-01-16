using Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Interface;

namespace UserContext.Application.src.Features.Profile.Command.DeleteMedicalInfo;

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
        var personFound = await _UnitOfWork.PersonReadRepository.GetByIdAsync(input.Id);
        if (personFound == null)
            return Result.Fail(new PersonNotExists());
        personFound.DeleteMedicalInfo();
        _UnitOfWork.PersonWriteRepository.Update(personFound);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}