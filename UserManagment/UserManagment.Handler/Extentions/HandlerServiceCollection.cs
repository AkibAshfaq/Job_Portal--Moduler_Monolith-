using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagment.AggregateRoot.Entities;
using UserManagment.AggregateRoot.Extentions;
using UserManagment.DTO.Command;
using UserManagment.DTO.Query;
using UserManagment.Handler.Abstractions;
using UserManagment.Handler.CommandHandlers;
using UserManagment.Handler.QueryHandler;
using UserManagment.Repository.Extensions;

namespace UserManagment.Handler.Extentions
{
    public static class HandlerServiceCollection
    {
        public static IServiceCollection AddHandlerLayer(this IServiceCollection services, IConfiguration config )
        {
            
            services.AddScoped<ICommandHandler<UserRegisterCommand>, UserRegistrationHandler>();
            services.AddScoped<ICommandHandler<UserUpdateCommand>, UserUpdateHandler>();
            services.AddScoped<ICommandHandler<UserDeleteCommand>, UserDeletationHandler>();
            services.AddScoped<IQueryHandler<GetUsersQuery, IEnumerable<User>>, GetUsersHandler>();
            services.AddDataAccessLayer(config);
            services.AddAggregator();
            return services;
        }
    }
}
