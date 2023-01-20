using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Profile;

public static class CreateAddress
{
     public static RouteGroupBuilder CreateAddressRoute(this RouteGroupBuilder route)
     {
        route.MapPost("/",CreateAddressController);
        return route;
     }

    internal static async void CreateAddressController(IProfileController profile)
    {
        var newProfile = await profile.CreateAddress(new(new(),"","","","",""));
    }
}
