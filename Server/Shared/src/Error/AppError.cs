using Shared.src.Interface.Error;

namespace Shared.src.Error
{
    public class AppError : IAppError
    {
        public int Code { get; init; }
        public string Message { get; init; }

        public AppError(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}