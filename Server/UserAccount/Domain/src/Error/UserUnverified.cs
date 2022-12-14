using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.Error
{
    public class UserUnverified : DomainError
    {
        public UserUnverified() : base(ErrorTypes.Conflict, "La cuenta no ha sido verificada. Revisa tu email")
        {
        }
    }
}