using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class ChangeAddress
{
    public static IEndpointRouteBuilder ChangeAddressRoute(this IEndpointRouteBuilder route)
    {
        route.MapPost("/", ChangeAddressController);
        return route;
    }

    internal static async void ChangeAddressController(IPersonController profile)
    {
        var newProfile = await profile.ChangeAddress(new(new(), "", "", "", "", ""));
    }
}
