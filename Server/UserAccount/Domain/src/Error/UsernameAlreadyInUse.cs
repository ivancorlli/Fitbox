using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.Error
{
    public class UsernameAlreadyInUse : DomainError
    {
        public UsernameAlreadyInUse(string username) : base(ErrorTypes.ValidationError, $"{username} ya ha sido registrado")
        {
        }
    }
}