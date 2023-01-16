
using Application.src.Features.Profile.Command.CreateAddress;
using Domain.src.Interface;
using Domain.src.Service;
using Infrastructure.src.Context;
using Infrastructure.src.Repository;
using Infrastructure.src.UOF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UserContext.Presentation.src.Extension;

internal static class Index
{
    internal static IServiceCollection ConfigureMediatR(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateAddressHandler).Assembly);
        services.AddMediatR(typeof(Index).Assembly);
        return services;
    }
    internal static IServiceCollection ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped<IAccountReadRepository, AccountReadRepository>();
        services.AddScoped<IAccountWriteRepository, AccountWriteRepository>();
        services.AddScoped<IPersonReadRepository, PersonReadRepository>();
        services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();
        return services;
    }

    internal static IServiceCollection ConfigureManager(this IServiceCollection services)
    {
        services.AddScoped<IAccountManager, AccountManager>();
        services.AddScoped<IPersonManager, PersonManager>();
        return services;
    }

    internal static IServiceCollection ConfigureUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    internal static IServiceCollection ConfigureDb(this IServiceCollection services)
    {
        var Connection = "server=localhost;port=3306;user=fitboxserver;password=A1jc8D62;database=usercontext";
        services.AddDbContext<UserDbContext>(
            opts => opts.UseMySql(
            Connection,
            ServerVersion.Create(
                    new Version(10, 6, 11),
                    ServerType.MariaDb
                ),
                opt => opt.EnableRetryOnFailure(
                            maxRetryCount: 4,
                            maxRetryDelay: TimeSpan.FromMilliseconds(2000),
                            errorNumbersToAdd: null)


            ));
        return services;
    }
}
