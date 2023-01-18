using Api.src.Routes.UserContext.Account;
using Api.src.Routes.UserContext.Profile;

namespace Api.src.Routes.UserContext;

internal static class UserContextRouter
{
    internal static RouteGroupBuilder ConfigureUserContextRouter(this RouteGroupBuilder router)
    {
        router.MapGroup("/user")
        .ConfigureAccountRouter()
        .ConfigureProfileRouter();
        return router;
    }
    
}
