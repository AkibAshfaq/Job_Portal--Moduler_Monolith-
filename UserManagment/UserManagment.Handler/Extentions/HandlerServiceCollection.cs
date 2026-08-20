using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagment.AggregateRoot.Extentions;
using UserManagment.Handler.CommandHandlers;
using UserManagment.Handler.QueryHandler;
using UserManagment.Repository.Extensions;

namespace UserManagment.Handler.Extentions
{
    public static class HandlerServiceCollection
    {
        public static IServiceCollection AddHandlerLayer(this IServiceCollection services, IConfiguration config )
        {
            
            services.AddScoped<UserRegistrationHandler>();
            services.AddScoped<UserUpdateHandler>();
            services.AddScoped<UserRegistrationHandler>();
            services.AddScoped<GetUsersHandler>();
            services.AddDataAccessLayer(config);
            services.AddAggregator();
            return services;
        }
    }
}
