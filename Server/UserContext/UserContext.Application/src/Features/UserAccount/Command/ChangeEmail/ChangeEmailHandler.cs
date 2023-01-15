using Application.src.Errors;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;
using SharedKernell.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.ChangeEmail
{
    public sealed class ChangeEmailHandler : IHandler<ChangeEmailCommand, Result>
    {
        private readonly IAccountManager _AccountManager;
        private readonly IUnitOfWork _UnitOfWork;

        public ChangeEmailHandler(IAccountManager accountManager, IUnitOfWork unitOfWork)
        {
            _AccountManager = accountManager;
            _UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
        {
            var input = request.Input;
            var newEmail = Email.Create(input.Email);
            if(newEmail.IsFailure)
                return Result.Fail(newEmail.Error);
            var accountExist = await _UnitOfWork.AccountReadRepository.GetByIdAsync(input.Id);
            if(accountExist == null)
                return Result.Fail(new AccountNotExists());
            var emailChanged = await _AccountManager.ChangeEmail(accountExist, newEmail.Value);
            if(emailChanged.IsFailure)
                    return Result.Fail(emailChanged.Error);
            _UnitOfWork.AccountWriteRepository.Update(accountExist);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}