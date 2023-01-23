using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Account;

public static class ChangeContact
{
    public static RouteGroupBuilder ChangeContactRoute(this RouteGroupBuilder route)
    {
        route.MapPost("/", ChangeContactController);
        return route;
    }

    internal static async void ChangeContactController(IAccountController profile)
    {
        var newContact = await profile.ChangeContact(new(new(), "", "", "", 0, 0, ""));
    }
}
