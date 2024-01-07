using Application.Services.Categorias;
using Application.Services.User;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationInjectionModule
    {
        public static void AddServicesModule(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoriasService, CategoriasService>();
        }
    }
}
