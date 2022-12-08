
using FluentResults;

namespace Domain.src.DomainError
{
    public class IncorrectPassword:Error
    {
        public IncorrectPassword():base("La contraseña es incorrecta"){}   
    }
}