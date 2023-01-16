using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error
{
    public class IncorrectPassword : DomainError
    {
        public IncorrectPassword() : base(ErrorTypes.Unauthorized, "La contraseña es incorrecta") { }
    }
}