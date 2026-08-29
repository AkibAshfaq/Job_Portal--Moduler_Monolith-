using JobPortal.Shared.Interfaces.CommandHandler;
using JobPortal.Shared.Interfaces.QueryHandler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SubscriptionPlan.AggregateRoot.Extentions;
using SubscriptionPlan.DTO.Command;
using SubscriptionPlan.DTO.Query;
using SubscriptionPlan.DTO.Response;
using SubscriptionPlan.Handler.CommandHandler;
using SubscriptionPlan.Handler.QueryHandler;
using SubscriptionPlan.Repository.Extention;

namespace SubscriptionPlan.Handler.Extentions
{
    public static class HandlerServiceCollection
    {
        public static IServiceCollection AddSubscriptionHandlerLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICommandHandler<RegisterSubscriptionCommand>, RegisterSubscriptionHandler>();
            services.AddScoped<ICommandHandler<UpdateSubscriptionCommand>, UpdateSubscriptionHandler>();
            services.AddScoped<ICommandHandler<RemoveSubscriptionCommand>, RemoveSubscriptionHandler>();
            services.AddScoped<IQueryHandler<ViewSubscriptionQuery, IEnumerable<ViewSubscriptionResponse>>, ViewSubscriptionHandler>();
            services.AddSubscriptionAggregateLayer();
            services.AddSubscriptionDataAccessLayer(configuration);
            return services;
        }

    }
}
