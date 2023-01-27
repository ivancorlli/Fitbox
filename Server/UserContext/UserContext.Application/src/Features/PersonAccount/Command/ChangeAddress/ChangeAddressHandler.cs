using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Errors;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.PersonAccount.Command.ChangeAddress
{
    public class ChangeAddressHandler : IHandler<ChangeAddressCommand, Result>
    {
        private readonly IUnitOfWork _UnitOfWork;

        public ChangeAddressHandler(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangeAddressCommand request, CancellationToken cancellationToken)
        {
            var input = request.Input;
            var account = await _UnitOfWork.PersonReadRepository.GetByIdAsync(input.Id);
            if (account == null)
                return Result.Fail(new AccountNotExists());
            var newZipCode = ZipCode.Create(input.zipCode);
            if (newZipCode.IsFailure)
                return Result.Fail(newZipCode.Error);
            var newAddress = Address.Create(input.coutry, input.city, input.state, newZipCode.Value);
            if (newAddress.IsFailure)
                return Result.Fail(newAddress.Error);
            if (account.Profile == null)
                return Result.Fail(new ProfileNotExists());
            account.Profile.CreateAddress(newAddress.Value);

            _UnitOfWork.PersonWriteRepository.Update(account);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}