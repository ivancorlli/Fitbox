namespace Api.src.Routes.UserContext.Profile;

public static class ProfileRouter
{
    public static RouteGroupBuilder ConfigureProfileRouter(this RouteGroupBuilder router)
    {
        router.MapGroup("/profile");
        return router;
    }
    
}