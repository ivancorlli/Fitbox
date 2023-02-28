using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error
{
    public class AccountDeleted : DomainError
    {
        public AccountDeleted(string user) : base(ErrorTypes.Conflict, $"La cuenta {user} ha sido eliminada")
        {
        }
    }
}