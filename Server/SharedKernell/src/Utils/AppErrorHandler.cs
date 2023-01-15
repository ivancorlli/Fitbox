using Shared.src.Constant;
using Shared.src.Interface.Error;
using SharedKernell.src.Error;

namespace Shared.src.Utils;

public class AppErrorHandler
{
    public static AppError GetError(IError domainError){
       AppError response = new AppError(500,"Se produjo un error interno al crear mensaje de error");
       if(domainError.Type == ErrorTypes.Validation)
       {
            response = new AppError(400,domainError.Message);
       }
        return response;
    }
}