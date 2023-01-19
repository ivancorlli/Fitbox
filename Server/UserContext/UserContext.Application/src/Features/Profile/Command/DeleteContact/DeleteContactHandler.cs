using UserContext.Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Interface;

namespace UserContext.Application.src.Features.Profile.Command.DeleteContact;

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
        var personFound = await _UnitOfWork.PersonReadRepository.GetByIdAsync(input.Id);
        if (personFound == null)
            return Result.Fail(new PersonNotExists());
        personFound.DeleteContact();
        _UnitOfWork.PersonWriteRepository.Update(personFound);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}