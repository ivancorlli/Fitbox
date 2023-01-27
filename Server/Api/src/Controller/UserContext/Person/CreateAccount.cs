using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class CreateAccount
{
    public static IEndpointRouteBuilder CreateAccountRoute(this IEndpointRouteBuilder router)
    {
        router.MapGet("/", async (IPersonController person) =>
        {
            try
            {
            var newAccount = await person.CreateAccount(new("ivancorlli","corlliivan@gmail.com","A1jc8D62"));
            return Results.Ok(newAccount);
            }catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
        return router;
    }
}
