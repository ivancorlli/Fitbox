
using Microsoft.Extensions.DependencyInjection;
using UserContext.App.src.Extension;

namespace UserContext.App.src.Startup;

public static class Index
{
    public static IServiceCollection ConfigureUserContext(this IServiceCollection services)
    {
        services.ConfigureDb()
                .ConfigureRepository()
                .ConfigureUnitOfWork()
                .ConfigureManager()
                .ConfigureMediatR();
        return services;
    }
}
