using Shared.src.Constant;
using SharedKernell.src.Error;

namespace Domain.src.Error
{
    public class UserInactive : DomainError
    {
        public UserInactive(string user) : base(ErrorTypes.Conflict,$"La cuenta {user} esta inactiva. Le hemos enviado un correo de re-activacion")
        {
        }
    }
}