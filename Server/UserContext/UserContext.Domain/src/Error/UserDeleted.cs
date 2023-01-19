using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error
{
    public class UserDeleted : DomainError
    {
        public UserDeleted(string user) : base(ErrorTypes.Conflict, $"La cuenta {user} ha sido eliminada")
        {
        }
    }
}