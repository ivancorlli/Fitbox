using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Account;

public static class ChangeMedicalInfo
{
    public static RouteGroupBuilder ChangeMedicalInfoRoute(this RouteGroupBuilder route)
    {
        route.MapPost("/", ChangeMedicalInfoController);
        return route;
    }

    internal static async void ChangeMedicalInfoController(IAccountController profile)
    {
        var newMedical = await profile.ChangeMedicalInfo(new(new(), ""));
    }
}
