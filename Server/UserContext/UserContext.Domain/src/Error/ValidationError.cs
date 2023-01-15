using Shared.src.Constant;
using SharedKernell.src.Error;

namespace Domain.src.Error
{
    public class ValidationError : DomainError
    {
        public ValidationError(string message) : base(ErrorTypes.Validation, message)
        {
        }
    }
}