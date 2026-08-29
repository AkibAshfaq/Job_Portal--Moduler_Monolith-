using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Repository.Context;
using UserManagement.Repository.Repositories;
using UserManagement.Repository.Repositories.Interfaces;

namespace UserManagement.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortalDbUserContext>(Options => 
            Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}