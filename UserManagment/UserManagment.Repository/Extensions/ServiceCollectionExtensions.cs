using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagment.Repository.Context;
using UserManagment.Repository.Repositories;



namespace UserManagment.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortalDbContext>(Options => 
            Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<UserUpdateRepository>();
            services.AddScoped<GetUserByMailRepository>();
            services.AddScoped<UserRegisterRepository>();
            services.AddScoped<GetUsersRepository>();
            return services;
        }
    }
}