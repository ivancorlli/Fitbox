
using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.Error
{
    public class EmailAlreadyInUse : DomainError
    {
        public EmailAlreadyInUse(string email) : base(ErrorTypes.Validation, $"{email} ya ha sido registrado")
        {
        }
    }
}