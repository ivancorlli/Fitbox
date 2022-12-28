using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.src.Constant;
using Shared.src.Error;

namespace Application.src.Errors
{
    public class MedicalNotExists : DomainError
    {
        public MedicalNotExists() : base(ErrorTypes.NotFound, "No existe un registro medico asociado a esta cuenta")
        {
        }

        public MedicalNotExists(string type, string message) : base(type, message)
        {
        }
    }
}