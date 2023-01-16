using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedKernell.src.Constant
{
    public abstract class ErrorTypes
    {
        public static readonly string NullValue = "NullValue";
        public static readonly string Empty = "";
        public static readonly string Unauthorized = "Error.Unauthorized";
        public static readonly string Validation = "Error.Validation";
        public static readonly string Failure = "Error.Failure";
        public static readonly string Unexpected = "Error.Unexpected";
        public static readonly string Conflict = "Error.Conflict";
        public static readonly string NotFound = "Error.NotFound";
    }
}