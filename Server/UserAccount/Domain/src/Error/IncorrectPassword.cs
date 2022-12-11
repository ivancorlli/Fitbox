using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.Error
{
    public class IncorrectPassword : DomainError
    {
        public IncorrectPassword() : base(ErrorTypes.Unauthorized,"La contraseña es incorrecta") { }
    }
}