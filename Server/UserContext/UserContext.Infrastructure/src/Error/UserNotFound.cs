using Shared.src.Constant;
using Shared.src.Interface.Error;

namespace Infrastructure.src.Error
{
    public sealed record UserNotFound : IError
    {
        public string Message  {get;init;}
        public string Type {get;init;}
        
        public UserNotFound()
        {
            Message = "No se encontro al usuario";
            Type = ErrorTypes.NotFound;
        }
    }
}