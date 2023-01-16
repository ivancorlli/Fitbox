using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error
{
    public class EmailAlreadyInUse : DomainError
    {
        public EmailAlreadyInUse(string email) : base(ErrorTypes.Validation, $"{email} ya ha sido registrado")
        {
        }
    }
}