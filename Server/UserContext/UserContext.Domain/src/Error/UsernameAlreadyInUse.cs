using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error
{
    public class UsernameAlreadyInUse : DomainError
    {
        public UsernameAlreadyInUse(string username) : base(ErrorTypes.Conflict, $"{username} ya ha sido registrado")
        {
        }
    }
}