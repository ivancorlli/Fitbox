using Api.src.Controller.UserContext.Account;

namespace Api.src.Routes.UserContext;

public static class AccountRouter
{
    public static RouteGroupBuilder ConfigureAccountRouter(this RouteGroupBuilder router)
    {
        router.MapGroup("/account")
            .CreateAccountRoute()
            .ChangeEmailRoute()
            .ChangeUsernameRoute()
            .ChangePhoneRoute()
            .ChangePasswordRoute()
            .VerifyEmailRoute()
            .VerifyPhoneRoute();
        return router;
    }

}