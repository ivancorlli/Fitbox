using UserContext.Presentation.src.Startup;

namespace Api.src.Extension;

public static class UserContextExtension
{

    public static IServiceCollection UserContextInstaller(this IServiceCollection services)
    {
        services.ConfigureUserContext();
        return services;
    }
}
