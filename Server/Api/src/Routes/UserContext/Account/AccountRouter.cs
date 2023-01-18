namespace Api.src.Routes.UserContext.Account;

internal static class AccountRouter
{
    internal static RouteGroupBuilder ConfigureAccountRouter(this RouteGroupBuilder router)
    {
        router.MapGroup("/account")
        .NewAccountController();
        return router;
    }
}