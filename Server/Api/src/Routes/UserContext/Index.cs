using UserContext.Presentation.src.Controller.Account;

namespace Api.src.Routes.UserContext;

public static class Index
{
    public static RouteGroupBuilder ConfigureUserContextRouter(this RouteGroupBuilder router)
    {
        router.MapGroup("/user")
            .CreateAccount()
            .GetMyAccount()
            .UpdateEmail()
            .UpdatePassword()
            .UpdatePhone()
            .UpdateUsername()
            .VerifyEmail()
            .VerifyPhone()
            ;
        return router;
    }
    
    internal static RouteGroupBuilder CreateAccount(this RouteGroupBuilder router)
    {
        router.MapPost("/", () => "Create Account");
        return router;
    }

    internal static RouteGroupBuilder GetMyAccount(this RouteGroupBuilder router) 
    {
        router.MapGet("/", () => "Get My Account");
        return router;
    }

    internal static RouteGroupBuilder UpdateEmail(this RouteGroupBuilder router)
    {
        router.MapPatch("/{id}", () => "Update Email");
        return router;
    }

    internal static RouteGroupBuilder UpdatePassword(this RouteGroupBuilder router)
    {
        router.MapPatch("/{id}", () => "Update Passowrd");
        return router;
    }

    internal static RouteGroupBuilder UpdatePhone(this RouteGroupBuilder router)
    {
        router.MapPatch("/{id}", () => "Update Phone");
        return router;
    }

    internal static RouteGroupBuilder UpdateUsername(this RouteGroupBuilder router)
    {
        router.MapPatch("/{id}", () => "Update Username");
        return router;
    }

    internal static RouteGroupBuilder VerifyEmail(this RouteGroupBuilder router)
    {
        router.MapPatch("/{id}",()=> "Verify Email");
        return router;
    }

    internal static RouteGroupBuilder VerifyPhone(this RouteGroupBuilder router)
    {
        router.MapPatch("/{id}",()=> "Verify Phone");
        return router;
    }
}
