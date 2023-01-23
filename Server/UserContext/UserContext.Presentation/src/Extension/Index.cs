﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserContext.Application.src.Features.Account.Command.CreateAddress;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.Repository;
using UserContext.Domain.src.Service;
using UserContext.Infrastructure.src.Context;
using UserContext.Infrastructure.src.Repository;
using UserContext.Infrastructure.src.UOF;
using UserContext.Presentation.src.Controller.Account;
using UserContext.Presentation.src.Interface;

namespace UserContext.Presentation.src.Extension;

internal static class Index
{
    internal static IServiceCollection ConfigureMediatR(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ChangeAddressHandler).Assembly);
        services.AddMediatR(typeof(Index).Assembly);
        return services;
    }
    internal static IServiceCollection ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped<IAccountReadRepository, AccountReadRepository>();
        services.AddScoped<IAccountWriteRepository, AccountWriteRepository>();
        return services;
    }

    internal static IServiceCollection ConfigureManager(this IServiceCollection services)
    {
        services.AddScoped<IAccountManager, AccountManager>();
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
        var serverVersion = new MySqlServerVersion(new Version(10, 6, 11));
        services.AddDbContext<UserDbContext>(
            opts => opts.UseMySql(
            Connection,
            serverVersion,
                opt => opt.EnableRetryOnFailure(
                            maxRetryCount: 4,
                            maxRetryDelay: TimeSpan.FromMilliseconds(2000),
                            errorNumbersToAdd: null
            )).EnableSensitiveDataLogging().EnableDetailedErrors() );
        return services;
    }

    internal static IServiceCollection ConfigureControllers(this IServiceCollection services)
    {
        services.AddScoped<IAccountController,AccountController>();
        return services;
    }
}
