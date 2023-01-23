using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error;

public class ProfileExists : DomainError
{
    public ProfileExists(string username) : base(ErrorTypes.Conflict, $"El usuario {username} ya ha creado su perfil")
    {
    }
}
