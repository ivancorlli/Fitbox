using Infrastructure.src.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.src.Extension
{
    public static class NewBaseType
    {
        public static void ConfigureUserAccountContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(opts =>
             opts.UseMySQL(configuration.GetConnectionString("UserAccountDB")!, x => x.MigrationsAssembly("Api"))
            );
        }
}

}