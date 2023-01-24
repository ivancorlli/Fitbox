using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error
{
    public class AccountInactive : DomainError
    {
        public AccountInactive(string user) : base(ErrorTypes.Conflict, $"La cuenta {user} esta inactiva. Le hemos enviado un correo de re-activacion")
        {
        }
    }
}