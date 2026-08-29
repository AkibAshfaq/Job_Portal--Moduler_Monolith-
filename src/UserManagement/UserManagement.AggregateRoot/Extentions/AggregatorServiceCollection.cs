using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.AggregateRoot.Mapping;
using UserManagement.AggregateRoot.Mapping.Interface;
using UserManagement.AggregateRoot.PasswordHasher;
using UserManagement.AggregateRoot.PasswordHasher.Interfaces;
using UserManagement.AggregateRoot.Validators;

namespace UserManagement.AggregateRoot.Extentions
{
    public static class AggregatorServiceCollection
    {
        public static IServiceCollection AddUserAggregatorLayer(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<UserDeleteCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UserRegisterCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UserUpdateCommandValidator>();
            services.AddScoped<UsersAggregateRoot>();
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IPasswordHasher,PasswordHash>();
            return services;
        }
    }
}
