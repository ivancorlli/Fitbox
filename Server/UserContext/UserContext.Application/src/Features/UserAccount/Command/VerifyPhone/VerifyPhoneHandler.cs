using UserContext.Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Interface;

namespace UserContext.Application.src.Features.UserAccount.Command.VerifyPhone;

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
        var accountExist = await _UnitOfWork.AccountReadRepository.GetByIdAsync(input.Id);
        if (accountExist == null)
            return Result.Fail(new AccountNotExists());
        accountExist.VerifyPhone();
        _UnitOfWork.AccountWriteRepository.Update(accountExist);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}