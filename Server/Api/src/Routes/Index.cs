using Api.src.Routes.UserContext;

namespace Api.src.Routes;

public static class Index
{
    public static IEndpointRouteBuilder ConfigureApiV1Router(this IEndpointRouteBuilder router)
    {
        var apiV1 = router.MapGroup("/v1");
            apiV1.ConfigureUserContextRouter();
        return apiV1;
    }

    
    internal static IEndpointRouteBuilder ConfigureUserContextRouter(this IEndpointRouteBuilder router)
    {
        var account = router.MapGroup("/account");
            account.ConfigurePersonRouter();
        return account;
    }
}
