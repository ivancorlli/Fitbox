using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Infrastructure.src.Context;

public class ContextFactory : IDesignTimeDbContextFactory<UserDbContext>
{
    private readonly string Connection = "server=localhost;port=3306;user=fitboxserver;password=A1jc8D62;database=usercontext";
    public UserDbContext CreateDbContext(string[] args)
    {
        var config = new DbContextOptionsBuilder<UserDbContext>();
        config.UseMySql(
            Connection,
            ServerVersion.Create(
                    new Version(10,6,11),
                    ServerType.MariaDb
                ),
                opt => opt.EnableRetryOnFailure(
                            maxRetryCount: 4,
                            maxRetryDelay: TimeSpan.FromMilliseconds(2000),
                            errorNumbersToAdd: null)
        );
        config.EnableDetailedErrors().EnableSensitiveDataLogging();
        return new UserDbContext(config.Options);
    }
}