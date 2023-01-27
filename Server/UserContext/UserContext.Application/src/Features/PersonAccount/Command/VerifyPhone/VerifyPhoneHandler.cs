using UserContext.Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Interface;

namespace UserContext.Application.src.Features.PersonAccount.Command.VerifyPhone;

public class VerifyPhoneHandler : IHandler<VerifyPhoneCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public VerifyPhoneHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(VerifyPhoneCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var accountExist = await _UnitOfWork.PersonReadRepository.GetByIdAsync(input.Id);
        if (accountExist == null)
            return Result.Fail(new AccountNotExists());
        accountExist.VerifyPhone();
        _UnitOfWork.PersonWriteRepository.Update(accountExist);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}