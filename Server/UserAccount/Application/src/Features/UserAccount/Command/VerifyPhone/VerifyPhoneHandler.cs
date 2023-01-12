
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
        var accountExists = await _UnitOfWork.AccountReadRepository.GetById(input.Id);
        var account = accountExists.Value;
        account.VerifyPhone();
        _UnitOfWork.AccountWriteRepository.Update(account);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}