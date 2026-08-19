using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestProject.DAL.Context;


namespace TestProject.DAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortalDbContext>(Options => 
            Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}