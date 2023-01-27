using UserContext.Application.src.Errors;
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;
using UserContext.Domain.src.Entity.Account;

namespace UserContext.Application.src.Features.PersonAccount.Command.ChangePhone
{
    public class ChangePhoneHandler : IHandler<ChangePhoneCommand, Result>
    {
        private readonly IAccountManager<Person> _AccountManager;
        private readonly IUnitOfWork _UnitOfWork;

        public ChangePhoneHandler(IAccountManager<Person> accountManager, IUnitOfWork unitOfWork)
        {
            _AccountManager = accountManager;
            _UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangePhoneCommand request, CancellationToken cancellationToken)
        {
            var input = request.input;
            var phone = Phone.Create(input.area, input.number);
            if (phone.IsFailure)
                return Result.Fail(phone.Error);
            var accountExist = await _UnitOfWork.PersonReadRepository.GetByIdAsync(input.id);
            if (accountExist == null)
                return Result.Fail(new AccountNotExists());
            var phoneChanged = await _AccountManager.ChangePhone(accountExist, phone.Value);
            if (phoneChanged.IsFailure)
                return Result.Fail(phoneChanged.Error);

            _UnitOfWork.PersonWriteRepository.Update(accountExist);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}