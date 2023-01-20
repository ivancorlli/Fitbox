using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Profile;

public static class DeleteMedicalInfo
{
    public static RouteGroupBuilder DeleteMedicalInfoRoute(this RouteGroupBuilder builder)
    {
        builder.MapPatch("/",DeleteMedicalInfoController);
        return builder;
    }
    internal static async void DeleteMedicalInfoController(IProfileController profile)
    {
        var medicalDelted = await profile.DeleteMedicalInfo(new(new()));
    }

}
