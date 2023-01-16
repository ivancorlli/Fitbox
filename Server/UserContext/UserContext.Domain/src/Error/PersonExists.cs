using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Domain.src.Error;

public class PersonExists : DomainError
{
    public PersonExists(string username) : base(ErrorTypes.Conflict, $"El usuario {username} ya ha creado su perfil")
    {
    }
}
