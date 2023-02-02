using Microsoft.AspNetCore.Mvc;
using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class CreateAccount
{
    public static IEndpointRouteBuilder CreateAccountRoute(this IEndpointRouteBuilder router)
    {
        router.MapPost("/", async ([FromServices] IPersonController person,NewPersonAccount body) =>
        {
            try
            {
                Console.WriteLine(body);
                var newAccount = await person.CreateAccount(new(body.Username, body.Email, body.Password));
                if (newAccount.IsFailure)
                    return Results.Problem(newAccount.Error.Message);
                return Results.Ok("Usuario creado");
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message.ToString());
            }
        });
        return router;
    }

    internal record NewPersonAccount(string Username,string Email,string Password);
}
