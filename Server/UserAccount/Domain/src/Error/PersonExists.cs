
using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.Error;

public class PersonExists : DomainError
{
    public PersonExists(string username) : base(ErrorTypes.Conflict,$"El usuario {username} ya ha creado su perfil")
    {
    }
}
