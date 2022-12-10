using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.src.Constant;
using Shared.src.Interface.Error;

namespace Shared.src.Error
{
    public class DomainError : IError
    {
        public string Message {get;}
        public string Type {get;}

        public DomainError(string type,string message)
        {
            Type = type;
            Message = message.ToLower().Trim();
        }

        public static readonly DomainError None = new (ErrorTypes.Empty,string.Empty);
        public static readonly DomainError NullValue = new (ErrorTypes.NullValue,"El valor del resultado es nulo");
    }
}