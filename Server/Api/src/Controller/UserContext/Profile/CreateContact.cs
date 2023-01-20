using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Profile;

public static class CreateContact
{
    public static RouteGroupBuilder CreateContactRoute(this RouteGroupBuilder route)
    {
        route.MapPost("/",CreateContactController);
        return route;
    }

    internal static async void CreateContactController(IProfileController profile)
    {
        var newContact = await profile.CreateContact(new(new(),"","","",0,0,""));
    }
}
