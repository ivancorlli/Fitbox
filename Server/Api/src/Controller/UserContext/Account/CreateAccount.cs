using Api.src.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Account;

public static class CreateAccount
{
    public static RouteGroupBuilder CreateAccountRoute(this RouteGroupBuilder router)
    {
        router.MapGet("/", CreateAccountController);
        return router;
    }
    internal static async Task<HttpContext> CreateAccountController(this HttpContext context, IAccountController account)
    {
        try
        {
            var body = context.Request.Body;
            var newAccount = await account.CreateAccount(new("ivancorlli", "ivancorlli@gmail.com", "A1jc8D62"));
            if (newAccount.IsFailure)
            {
                context = ResponseHandler.CreateErrorResponse(context, newAccount.Error);
            }
            else
            {
                context = ResponseHandler.CreateOkResponse(context, System.Net.HttpStatusCode.Created, "Cuenta Creada");
            }

        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            //context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(ex.ToString());
        }

        return context;
    }
}
