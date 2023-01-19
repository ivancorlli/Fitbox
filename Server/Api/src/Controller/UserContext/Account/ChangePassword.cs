using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Account;

public static class ChangePassword
{
    public static RouteGroupBuilder ChangePasswordRoute(this RouteGroupBuilder route)
    {
        route.MapPatch("/", ChangePasswordController);
        return route;
    }

    internal static async void ChangePasswordController(IAccountController account)
    {
        var newPassword = await account.ChangePassword(new(Guid.NewGuid(), ""));
    }
}
