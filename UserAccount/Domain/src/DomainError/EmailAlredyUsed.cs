
using Domain.src.ValueObject;
using FluentResults;

namespace Domain.src.DomainError
{
    public class EmailAlredyUsed:Error
    {

        public EmailAlredyUsed(Email email):base($"El email {email.Value} ya esta en uso."){

        }
        
    }
}