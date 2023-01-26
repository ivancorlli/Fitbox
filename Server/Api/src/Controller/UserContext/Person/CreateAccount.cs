using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class CreateAccount
{
    public static RouteGroupBuilder CreateAccountRoute(this RouteGroupBuilder router)
    {
        router.MapGet("/", async (IPersonController person) =>
        {
            var newAccount = await person.CreateAccount(new("","",""));
            return Results.Accepted("Cuenta creada exitosamente");
        });
        return router;
    }
}
