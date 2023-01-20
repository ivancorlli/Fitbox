using UserContext.Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Interface;

namespace UserContext.Application.src.Features.Account.Command.VerifyEmail;

public class VerifyEmailHandler : IHandler<VerifyEmailCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public VerifyEmailHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var accountExist = await _UnitOfWork.AccountReadRepository.GetByIdAsync(input.Id);
        if (accountExist == null)
            return Result.Fail(new AccountNotExists());
        accountExist.VerifyEmail();
        _UnitOfWork.AccountWriteRepository.Update(accountExist);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}