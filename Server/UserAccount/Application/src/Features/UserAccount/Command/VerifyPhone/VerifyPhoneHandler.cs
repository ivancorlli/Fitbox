
using Application.src.Errors;
using Domain.src.Interface;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.VerifyPhone;

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
        if(accountExist == null)
            return Result.Fail(new AccountNotExists());
        accountExist.VerifyPhone();
        _UnitOfWork.AccountWriteRepository.Update(accountExist);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}