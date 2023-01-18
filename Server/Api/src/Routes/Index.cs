using Api.src.Routes.UserContext;

namespace Api.src.Routes;

internal static class Index
{
    internal static IEndpointRouteBuilder ConfigureApiV1Router(this IEndpointRouteBuilder router)
    {
        router.MapGroup("/v1")
              .ConfigureUserContextRouter();
        return router;
    }

}
