using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Account;

public static class VerifyEmail
{
    public static RouteGroupBuilder VerifyEmailRoute(this RouteGroupBuilder builder)
    {
        builder.MapPatch("/",);
        return builder;
    }

    internal static async void VerifyEmailController(IAccountController account)
    {
        var emailVerified = await account.VerifyEmail(new(Guid.NewGuid()));
    }
}
