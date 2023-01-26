using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class ChangeMedicalInfo
{
    public static RouteGroupBuilder ChangeMedicalInfoRoute(this RouteGroupBuilder route)
    {
        route.MapPost("/", ChangeMedicalInfoController);
        return route;
    }

    internal static async void ChangeMedicalInfoController(IPersonController profile)
    {
        var newMedical = await profile.ChangeMedicalInfo(new(new(), ""));
    }
}
