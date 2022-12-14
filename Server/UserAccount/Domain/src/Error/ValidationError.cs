using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.Error
{
    public class ValidationError : DomainError
    {
        public ValidationError(string message) : base(ErrorTypes.Validation, message)
        {
        }
    }
}