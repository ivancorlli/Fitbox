using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class ChangeEmail
{
    public static RouteGroupBuilder ChangeEmailRoute(this RouteGroupBuilder router)
    {
        router.MapPatch("/", ChangeEmailController);
        return router;
    }

    internal static async void ChangeEmailController(IPersonController account)
    {
        var newEmail = await account.ChangeEmail(new(Guid.NewGuid(), ""));
    }
}
