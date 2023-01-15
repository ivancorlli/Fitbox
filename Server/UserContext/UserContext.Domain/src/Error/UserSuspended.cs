using Shared.src.Constant;
using SharedKernell.src.Error;
namespace Domain.src.Error
{
    public class UserSuspended : DomainError
    {
        public UserSuspended(string user) : base(ErrorTypes.Conflict,$"La cuenta {user} esta suspendida")
        {
        }
    }
}