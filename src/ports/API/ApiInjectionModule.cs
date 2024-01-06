﻿using API.Controllers.Presenters.User;

namespace API
{
    public static class ApiInjectionModule
    {
        public static void AddPresenterModule(this IServiceCollection services)
        {
            services.AddScoped<IUserPresenter, UserPresenter>();
        }
    }
}
