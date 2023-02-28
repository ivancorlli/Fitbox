using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error
{
    public class AccountNotFound : DomainError
    {
        public AccountNotFound(): base(ErrorTypes.NotFound, "Cuenta inexistente") { }
        public AccountNotFound(string user) : base(ErrorTypes.NotFound, $"No se encontro al usuario {user}")
        {
        }
    }
}