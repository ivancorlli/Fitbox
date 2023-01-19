
using Microsoft.Extensions.DependencyInjection;
using UserContext.Presentation.src.Extension;

namespace UserContext.Presentation.src.Startup;

public static class Index
{
    public static IServiceCollection ConfigureUserContext(this IServiceCollection services)
    {
        services.ConfigureDb()
                .ConfigureRepository()
                .ConfigureUnitOfWork()
                .ConfigureManager()
                .ConfigureMediatR()
                .ConfigureControllers();
        return services;
    }
}
