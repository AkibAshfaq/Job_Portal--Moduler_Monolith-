using Microsoft.Extensions.DependencyInjection;
using SubscriptionPlan.AggregateRoot.Mapping;
using SubscriptionPlan.AggregateRoot.Mapping.Interface;

namespace SubscriptionPlan.AggregateRoot.Extentions
{
    public static class AggregateServiceCollection
    {
        public static IServiceCollection AddSubscriptionAggregateLayer(this IServiceCollection services)
        {
            services.AddScoped<SubscriptionPlanAggregateRoot>();
            services.AddScoped<IMapper, Mapper>();
            return services;
        }
    }
}
