using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class ChangePassword
{
    public static RouteGroupBuilder ChangePasswordRoute(this RouteGroupBuilder route)
    {
        route.MapPatch("/", ChangePasswordController);
        return route;
    }

    internal static async void ChangePasswordController(IPersonController account)
    {
        var newPassword = await account.ChangePassword(new(Guid.NewGuid(), ""));
    }
}
