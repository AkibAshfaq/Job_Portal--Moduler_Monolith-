using Microsoft.Extensions.DependencyInjection;
using UserManagment.AggregateRoot.Aggregates;
using UserManagment.AggregateRoot.PasswordHasher;
using UserManagment.AggregateRoot.PasswordHasher.Interfaces;

namespace UserManagment.AggregateRoot.Extentions
{
    public static class AggregatorServiceCollection
    {
        public static IServiceCollection AddAggregator(this IServiceCollection services)
        {
            services.AddScoped<UserRegisterAggregate>();
            services.AddScoped<UserUpdateAggregate>();
            services.AddScoped<IPasswordHasher,PasswordHash>();
            return services;
        }
    }
}
