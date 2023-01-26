using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class VerifyEmail
{
    public static RouteGroupBuilder VerifyEmailRoute(this RouteGroupBuilder builder)
    {
        builder.MapPatch("/", VerifyEmailController);
        return builder;
    }

    internal static async void VerifyEmailController(IPersonController account)
    {
        var emailVerified = await account.VerifyEmail(new(Guid.NewGuid()));
    }
}
