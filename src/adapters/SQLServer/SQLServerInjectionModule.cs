using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SQLServer.Context;
using SQLServer.Repositories;

namespace SQLServer
{
    public static class SQLServerInjectionModule
    {
        public static void AddReositoryModule(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddSQLServerModule(this IServiceCollection services, string connection)
        {
            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(connection);
            });
        }
    }
}
