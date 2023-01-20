using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Profile;

public static class DeleteContact
{
    public static RouteGroupBuilder DeleteContactRoute(this RouteGroupBuilder builder)
    {
        builder.MapPatch("/",DeleteContactController);
        return builder;
    }

    internal static async void DeleteContactController(IProfileController profile)
    {
        var newProfile = await profile.DeleteContact(new(new()));
    }
}
