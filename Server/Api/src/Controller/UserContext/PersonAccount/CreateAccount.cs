using Api.src.Utils;
using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.PersonAccount;

public static class CreateAccount
{
    public static IEndpointRouteBuilder CreateAccountController(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("/", async (
            IPersonController controller,
            CreateAccountBody Body
            ) =>
        {
            try
            {
                var person = await controller.CreateAccount(new(Body.Username,Body.Email,Body.Password));
                if(person.IsFailure)
                    return ResponseHandler.HandleError(person.Error);
                return Results.Created("Response",person.Value);
            }catch(Exception ex)
            {
                return ResponseHandler.HandleEx(ex);
            }

        });
        return builder;
    }

    internal record CreateAccountBody(string Username,string Email,string Password);
}
