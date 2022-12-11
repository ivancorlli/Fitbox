
using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.Error
{
    public class PhoneAlreadyInUse : DomainError
    {
        public PhoneAlreadyInUse(string phoneNumber) : base(ErrorTypes.Conflict, $"{phoneNumber} ya ha sido registrado")
        {
        }
    }
}