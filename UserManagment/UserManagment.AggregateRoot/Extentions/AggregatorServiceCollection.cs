using Microsoft.Extensions.DependencyInjection;
using UserManagment.AggregateRoot.Aggregates;
using UserManagment.AggregateRoot.Aggregates.Interfaces;
using UserManagment.AggregateRoot.PasswordHasher;
using UserManagment.AggregateRoot.PasswordHasher.Interfaces;

namespace UserManagment.AggregateRoot.Extentions
{
    public static class AggregatorServiceCollection
    {
        public static IServiceCollection AddAggregator(this IServiceCollection services)
        {
            services.AddScoped<IUserRegisterAggregate, UserRegisterAggregate>();
            services.AddScoped<IUserUpdateAggregate, UserUpdateAggregate>();
            services.AddScoped<IPasswordHasher,PasswordHash>();
            return services;
        }
    }
}
