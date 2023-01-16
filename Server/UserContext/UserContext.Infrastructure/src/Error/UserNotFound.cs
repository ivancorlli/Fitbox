using SharedKernell.src.Constant;
using SharedKernell.src.Interface.Error;

namespace UserContext.Infrastructure.src.Error
{
    public sealed record UserNotFound : IError
    {
        public string Message { get; init; }
        public string Type { get; init; }

        public UserNotFound()
        {
            Message = "No se encontro al usuario";
            Type = ErrorTypes.NotFound;
        }
    }
}