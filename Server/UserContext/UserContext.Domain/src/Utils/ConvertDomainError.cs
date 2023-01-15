using FluentValidation.Results;
using SharedKernell.src.Error;

namespace Domain.src.Utils
{
    public class ConvertDomainError
    {
        public static List<DomainError> Convert(ValidationResult result)
        {
            List<DomainError> errors = new();
            foreach (var error in result.Errors)
            {
                var newDomainError =  new DomainError(error.ErrorCode,error.ErrorMessage);
                errors.Add(newDomainError);
            }

            return errors;
        }
    }
}