using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Application.src.Errors
{
    public class ContactNotExists : DomainError
    {
        public ContactNotExists() : base(ErrorTypes.NotFound, "No existe un contacto asociado a esta cuenta")
        {
        }
        public ContactNotExists(string message) : base(ErrorTypes.NotFound, message)
        {
        }
    }
}