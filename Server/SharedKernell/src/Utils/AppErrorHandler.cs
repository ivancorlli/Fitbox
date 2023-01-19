using SharedKernell.src.Constant;
using SharedKernell.src.Error;
using SharedKernell.src.Interface.Error;

namespace SharedKernell.src.Utils;

public class AppErrorHandler
{
    public static AppError GetError(IError domainError)
    {
        AppError response = new AppError(500, "Se produjo un error interno al crear mensaje de error");
        if (domainError.Type == ErrorTypes.Validation)
        {
            response = new AppError(400, domainError.Message);
        }
        return response;
    }
}