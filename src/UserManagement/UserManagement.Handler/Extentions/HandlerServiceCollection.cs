using JobPortal.Shared.Interfaces.CommandHandler;
using JobPortal.Shared.Interfaces.QueryHandler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.AggregateRoot;
using UserManagement.DTO.Command;
using UserManagement.DTO.Query;
using UserManagement.Handler.CommandHandlers;
using UserManagement.Handler.QueryHandler;
using UserManagement.Repository.Extensions;
using UserManagement.AggregateRoot.Extentions;

namespace UserManagement.Handler.Extentions
{
    public static class HandlerServiceCollection
    {
        public static IServiceCollection AddUserHandlerLayer(this IServiceCollection services, IConfiguration config )
        {
            services.AddScoped<ICommandHandler<UserRegisterCommand>, UserRegistrationHandler>();
            services.AddScoped<ICommandHandler<UserUpdateCommand>, UserUpdateHandler>();
            services.AddScoped<ICommandHandler<UserDeleteCommand>, UserDeletationHandler>();
            services.AddScoped<IQueryHandler<GetUsersQuery, IEnumerable<UsersAggregateRoot>>, GetUsersHandler>();
            services.AddUserDataAccessLayer(config);
            services.AddUserAggregatorLayer();
            return services;
        }
    }
}
