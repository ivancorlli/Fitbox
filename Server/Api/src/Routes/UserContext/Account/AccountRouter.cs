using UserContext.Presentation.src.Interface;

namespace Api.src.Routes.UserContext.Account;

public static class AccountRouter
{
    public static RouteGroupBuilder ConfigureAccountRouter(this RouteGroupBuilder router)
    {
        router.MapGroup("/account");
        return router;
    }


    public static RouteGroupBuilder CreateAccountController(this RouteGroupBuilder router)
    {
        router.MapPost("/", async (IAccountController account) =>
        {
            var newAccount = await account.CreateAccount(new("","",""));
            if (newAccount.IsFailure) 
            {
                return newAccount.Error.Message.ToString();
            }
            return "Nuevo usuario creado";
        });
        return router;
    }
}