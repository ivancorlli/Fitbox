using SharedKernell.src.Constant;
using SharedKernell.src.Interface.Error;

namespace SharedKernell.src.Error;

public class AppError : IAppError
    {
        public int Code { get; init; }
        public string Message { get; init; }

        internal AppError(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }

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