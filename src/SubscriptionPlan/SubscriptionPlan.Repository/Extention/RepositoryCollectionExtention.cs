
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SubscriptionPlan.Repository.Context;
using SubscriptionPlan.Repository.Repositories;
using SubscriptionPlan.Repository.Repositories.Interfaces;

namespace SubscriptionPlan.Repository.Extention
{
    public static class RepositoryCollectionExtention
    {
        public static IServiceCollection AddSubscriptionDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortalDbSubscriptionContext>(Options =>
            Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ISubscriptionPlanRepository, SubscriptionPlanRepository>();
            return services;
        }

    }
}
