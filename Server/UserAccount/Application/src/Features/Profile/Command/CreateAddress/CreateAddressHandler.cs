
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.CreateAddress
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
            var personFound = await _UnitOfWork.PersonReadRepository.GetById(input.Id);
            var person = personFound.Value;
            var newZipCode = ZipCode.Create(input.zipCode);
            if (newZipCode.IsFailure)
                return Result.Fail(newZipCode.Error);
            var newAddress = Address.Create(input.coutry,input.city,input.state,newZipCode.Value);
            if (newAddress.IsFailure)
                return Result.Fail(newAddress.Error);
            person.CreateAddress(newAddress.Value);

            _UnitOfWork.PersonWriteRepository.Update(person);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}