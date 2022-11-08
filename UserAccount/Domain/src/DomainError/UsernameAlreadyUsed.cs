using Domain.src.ValueObject;
using FluentResults;
namespace Domain.src.DomainError
{
    public class UsernameAlreadyUsed:Error
    {
        public UsernameAlreadyUsed(Username username):base($"El nombre de usuario {username.Value} ya esta en uso."){

        }
        
    }
}