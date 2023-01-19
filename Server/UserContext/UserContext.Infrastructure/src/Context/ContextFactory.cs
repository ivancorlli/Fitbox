using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace UserContext.Infrastructure.src.Context;

public class ContextFactory : IDesignTimeDbContextFactory<UserDbContext>
{
    private readonly string Connection = "server=localhost;port=3306;user id=fitboxserver;password=A1jc8D62;database=usercontext";
    public UserDbContext CreateDbContext(string[] args)
    {
        var serverVersion = new MySqlServerVersion(new Version(10,10,2));
        var config = new DbContextOptionsBuilder<UserDbContext>();
        config.UseMySql(Connection,serverVersion).EnableDetailedErrors();
        config.EnableDetailedErrors().EnableSensitiveDataLogging();
        return new UserDbContext(config.Options);
    }
}