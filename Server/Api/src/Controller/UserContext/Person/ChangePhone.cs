using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class ChangePhone
{
    public static RouteGroupBuilder ChangePhoneRoute(this RouteGroupBuilder route)
    {
        route.MapPatch("/", ChangePhoneController);
        return route;
    }

    internal static async void ChangePhoneController(IPersonController account)
    {
        var newPhone = await account.ChangePhone(new(Guid.NewGuid(), 0, 0, ""));
    }
}
