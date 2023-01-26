using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Errors;
using UserContext.Domain.src.Interface;

namespace UserContext.Application.src.Features.Person.Command.ChangePassword
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
            var accountExist = await _UnitOfWork.PersonReadRepository.GetByIdAsync(input.Id);
            if (accountExist == null)
                return Result.Fail(new AccountNotExists());
            var passChanged = accountExist.ChangePassword(input.Password);
            if (passChanged.IsFailure)
                return Result.Fail(passChanged.Error);

            _UnitOfWork.PersonWriteRepository.Update(accountExist);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}