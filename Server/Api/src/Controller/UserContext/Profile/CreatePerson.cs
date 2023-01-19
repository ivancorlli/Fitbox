using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Profile;

public static class CreatePerson
{
    public static RouteGroupBuilder CreatePersonRoute(this RouteGroupBuilder route)
    {
        route.MapPost("/",CreatePersonController);
        return route;
    }

    internal static async void CreatePersonController(IProfileController profile)
    {
        var newProfile = await profile.CreatePerson(new(new(),"","","",DateTime.Now));
    }

}
