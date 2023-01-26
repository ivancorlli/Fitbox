using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class ChangeProfile
{
    public static RouteGroupBuilder ChangeProfileRoute(this RouteGroupBuilder route)
    {
        route.MapPost("/", ChangeProfileController);
        return route;
    }

    internal static async void ChangeProfileController(IPersonController profile)
    {
        var newProfile = await profile.ChangeProfile(new(new(), "", "", "", DateTime.Now));
    }

}
