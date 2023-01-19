using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Account;

public static class ChangeUsername
{
    public static RouteGroupBuilder ChangeUsernameRoute(this RouteGroupBuilder route)
    {
        route.MapPatch("/", ChangeUsernameController);
        return route;
    }

    internal static async void ChangeUsernameController(IAccountController account)
    {
        var newUsername = await account.ChangeUsername(new(Guid.NewGuid(), ""));
    }
}
