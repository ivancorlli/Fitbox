using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error
{
    public class PhoneAlreadyInUse : DomainError
    {
        public PhoneAlreadyInUse(string phoneNumber) : base(ErrorTypes.Conflict, $"{phoneNumber} ya ha sido registrado")
        {
        }
    }
}