using JobPortal.Shared.Interfaces.Command;
using JobPortal.Shared.Interfaces.Query;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.DTO.Command;
using UserManagement.DTO.Query;
using UserManagement.DTO.Responses;
using UserManagement.DTO.Responses.Abstractions;

namespace UserManagement.DTO.Extentions
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
