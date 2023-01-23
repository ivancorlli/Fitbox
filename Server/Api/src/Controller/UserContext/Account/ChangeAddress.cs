using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Account;

public static class ChangeAddress
{
    public static RouteGroupBuilder ChangeAddressRoute(this RouteGroupBuilder route)
    {
        route.MapPost("/", ChangeAddressController);
        return route;
    }

    internal static async void ChangeAddressController(IAccountController profile)
    {
        var newProfile = await profile.ChangeAddress(new(new(), "", "", "", "", ""));
    }
}
