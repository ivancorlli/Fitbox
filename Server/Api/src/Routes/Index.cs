using Api.src.Routes.UserContext;

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
        router.MapGroup("/account")
            .ConfigurePersonRouter();
        return router;
    }
}
