using Microsoft.Extensions.DependencyInjection;
using UserManagment.DTO.Command;
using UserManagment.DTO.Command.Abstractions;
using UserManagment.DTO.Query;
using UserManagment.DTO.Query.Abstractions;
using UserManagment.DTO.Responses;
using UserManagment.DTO.Responses.Abstractions;

namespace UserManagment.DTO.Extentions
{
    public static class DTOServiceExtentions
    {
        public static IServiceCollection AddDTOService(this IServiceCollection services)
        {
            services.AddScoped<ICommand, UserRegisterCommand>();
            services.AddScoped<ICommand, UserUpdateCommand>();
            services.AddScoped<IQuery, SearchRequest>();
            services.AddScoped<IResponse, UserRegisterResponse>();
            services.AddScoped<IResponse, UserUpdateResponse>();
            return services;
        }

    }
}
