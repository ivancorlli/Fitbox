using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.Error
{
    public class UserDeleted : DomainError
    {
        public UserDeleted(string user) : base(ErrorTypes.Conflict, $"La cuenta {user} ha sido eliminada")
        {
        }
    }
}