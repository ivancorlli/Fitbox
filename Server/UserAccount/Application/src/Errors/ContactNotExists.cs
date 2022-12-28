using Shared.src.Constant;
using Shared.src.Error;
namespace Application.src.Errors
{
    public class ContactNotExists : DomainError
    {
         public ContactNotExists() : base(ErrorTypes.NotFound, "No existe un contacto asociado a esta")
        {
        }
        public ContactNotExists(string message) : base(ErrorTypes.NotFound, message )
        {
        }
    }
}