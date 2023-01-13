
using Application.src.Errors;
using Domain.src.Interface;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.ChangePassword
{
    public sealed class ChangePasswordHandler : IHandler<ChangePasswordCommand, Result>
    {
         private readonly IUnitOfWork _UnitOfWork;

        public ChangePasswordHandler(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var input = request.Input;
            var accountExist= await _UnitOfWork.AccountReadRepository.GetByIdAsync(input.Id);
            if(accountExist == null)
                return Result.Fail(new AccountNotExists());
            var passChanged = accountExist.ChangePassword(input.Password);
            if(passChanged.IsFailure)
                return Result.Fail(passChanged.Error);

            _UnitOfWork.AccountWriteRepository.Update(accountExist);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}