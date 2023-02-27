using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error
{
    public class AccountSuspended : DomainError
    {
        public AccountSuspended(string user) : base(ErrorTypes.Conflict, $"La cuenta {user} esta suspendida")
        {
        }
    }
}