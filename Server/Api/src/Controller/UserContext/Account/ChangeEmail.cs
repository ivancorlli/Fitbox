using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Account;

public static class ChangeEmail
{
    public static RouteGroupBuilder ChangeEmailRoute(this RouteGroupBuilder router)
    {
        router.MapPatch("/", ChangeEmailController);
        return router;
    }

    internal static async void ChangeEmailController(IAccountController account)
    {
        var newEmail = await account.ChangeEmail(new(Guid.NewGuid(), ""));
    }
}
