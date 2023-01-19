using Microsoft.AspNetCore.Mvc;
using SharedKernell.src.Interface.Error;
using SharedKernell.src.Utils;
using System.Net;

namespace Api.src.Utils;

public class ResponseHandler
{

    public static HttpContext CreateErrorResponse(HttpContext context,IError error)
    {
        var getError = AppErrorHandler.GetError(error);
        var result = new JsonResult(new {Ok=false,StatusCode=getError.Code,Message=getError.Message.ToString()});
        //context.Response.ContentType = "application/json";
        context.Response.StatusCode = getError.Code;
        //await context.Response.WriteAsJsonAsync(result);
        context.Response.WriteAsync("Nuevo Error");
        return context;
    }

    public static HttpContext CreateOkResponse(HttpContext context,HttpStatusCode statusCode, string message) 
    {
        //context.Response.ContentType= "application/json";
        context.Response.StatusCode = ((int)statusCode);
        //context.Response.WriteAsJsonAsync(new{Ok=true,StatusCode=((int)statusCode),Response=message});
        context.Response.WriteAsync("Nuevo");
        return context;
    }

    public static HttpContext CreateOkResponse<T>(HttpContext context, HttpStatusCode statusCode, T type)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ((int)statusCode);
        context.Response.WriteAsJsonAsync(new { Ok = true, StatusCode = ((int)statusCode), Response = type });
        return context;
    }

}
