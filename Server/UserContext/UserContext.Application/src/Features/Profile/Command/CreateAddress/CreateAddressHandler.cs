using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Errors;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.Profile.Command.CreateAddress
{
    public class CreateAddressHandler : IHandler<CreateAddressCommand, Result>
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CreateAddressHandler(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var input = request.Input;
            var personFound = await _UnitOfWork.PersonReadRepository.GetByIdAsync(input.Id);
            if (personFound == null)
                return Result.Fail(new PersonNotExists());
            var newZipCode = ZipCode.Create(input.zipCode);
            if (newZipCode.IsFailure)
                return Result.Fail(newZipCode.Error);
            var newAddress = Address.Create(input.coutry, input.city, input.state, newZipCode.Value);
            if (newAddress.IsFailure)
                return Result.Fail(newAddress.Error);
            personFound.CreateAddress(newAddress.Value);

            _UnitOfWork.PersonWriteRepository.Update(personFound);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}