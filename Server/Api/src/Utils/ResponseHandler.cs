using SharedKernell.src.Interface.Error;
using SharedKernell.src.Utils;
using System.Net;

namespace Api.src.Utils;

public class ResponseHandler
{

    public static IResult HandleError(IError error)
    {
        var getError = AppErrorHandler.GetError(error);
        switch (getError.Code)
        {
            case (int)HttpStatusCode.BadRequest:
                return Results.BadRequest(getError.Message);
            default:
                return Results.Problem(getError.Message);
        }

    }

   public static IResult HandleEx(Exception ex)
    {
        return Results.Problem(ex.StackTrace?.ToString().Trim(), null, 500, ex.Message.ToString());
    }

}
