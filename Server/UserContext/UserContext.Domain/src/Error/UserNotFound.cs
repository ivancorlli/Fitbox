using Shared.src.Constant;
using SharedKernell.src.Error;

namespace Domain.src.Error
{
    public class UserNotFound : DomainError
    {
        public UserNotFound(string user) : base(ErrorTypes.NotFound, $"No se encontro al usuario {user}")
        {
        }
    }
}