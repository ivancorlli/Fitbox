
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
            var profileFound = await _UnitOfWork.UserReadRepository.GetById(input.Id);
            var profile = profileFound.Value;
            var newZipCode = ZipCode.Create(input.zipCode);
            var newAddress = Address.Create(input.coutry,input.city,input.state,newZipCode.Value);
            profile.CreateAddress(newAddress.Value);
            await _UnitOfWork.UserWriteRepository.Update(profile);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}