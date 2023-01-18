using Api.src.Routes.UserContext.Account;
using Api.src.Routes.UserContext.Profile;

namespace Api.src.Routes;

public static class Index
{
    public static IEndpointRouteBuilder ConfigureApiV1Router(this IEndpointRouteBuilder router)
    {
        router.MapGroup("/v1")
              .ConfigureUserContextRouter();
        return router;
    }

    
    internal static RouteGroupBuilder ConfigureUserContextRouter(this RouteGroupBuilder router)
    {
        router.MapGroup("/user")
            .ConfigureAccountRouter()
            .ConfigureProfileRouter();
        return router;
    }
}
