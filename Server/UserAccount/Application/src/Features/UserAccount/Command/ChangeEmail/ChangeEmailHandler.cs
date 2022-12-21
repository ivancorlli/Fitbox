using Domain.src.Interface;
using Shared.src.Error;
using Shared.src.Interface.Command;

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
            var newEmail = await _AccountManager.CreateEmail(input.Email);
            if(newEmail.IsFailure)
                return Result.Fail(newEmail.Error);
            var userExist = await _UnitOfWork.AccountReadRepository.GetUserById(input.Id);
            var user = userExist.Value;
            user.ChangeEmail(newEmail.Value);
            await _UnitOfWork.AccountWriteRepository.Update(user);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok(user);
        }
    }
}