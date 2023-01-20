using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Profile;

public  static class CreateMedicalInfo
{
    public static RouteGroupBuilder CreateMedicalInfoRoute(this RouteGroupBuilder route)
    {
        route.MapPost("/",CreateMedicalInfoController);
        return route;
    }

    internal static async void CreateMedicalInfoController(IProfileController profile)
    {
        var newMedical = await profile.CreateMedicalInfo(new(new(),""));
    }
}
