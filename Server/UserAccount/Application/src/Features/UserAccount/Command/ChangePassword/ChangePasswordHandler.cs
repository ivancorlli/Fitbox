
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
            var userExist= await _UnitOfWork.AccountReadRepository.GetUserById(input.Id);
            var user = userExist.Value;
            var passChanged = user.ChangePassword(input.Password);
            if(passChanged.IsFailure)
                return Result.Fail(passChanged.Error);

            await _UnitOfWork.AccountWriteRepository.Update(user);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}