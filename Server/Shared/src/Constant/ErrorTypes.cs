using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.src.Constant
{
    public abstract class ErrorTypes
    {
        public static readonly string ValidationError = "ValidationError";
        public static readonly string NullValue ="NullValue";
        public static readonly string Empty ="";
        public static readonly string AthorizationError ="AuthorizationError";
        public static readonly string AuthenticationError ="AuthenticationError";
    }
}