using Api.src.Controller.UserContext.Profile;

namespace Api.src.Routes.UserContext;

public static class ProfileRouter
{
    public static RouteGroupBuilder ConfigureProfileRouter(this RouteGroupBuilder router)
    {
        router.MapGroup("/profile")
            .CreatePersonRoute();
        return router;
    }

}