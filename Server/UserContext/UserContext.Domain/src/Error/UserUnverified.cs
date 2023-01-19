using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error
{
    public class UserUnverified : DomainError
    {
        public UserUnverified() : base(ErrorTypes.Conflict, "La cuenta no ha sido verificada. Revisa tu email")
        {
        }
    }
}