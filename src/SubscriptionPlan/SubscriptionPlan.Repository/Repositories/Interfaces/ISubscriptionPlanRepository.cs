using SubscriptionPlan.AggregateRoot;


namespace SubscriptionPlan.Repository.Repositories.Interfaces
{
    public interface ISubscriptionPlanRepository : IGenericRepository<SubscriptionPlanAggregateRoot>
    {
        SubscriptionPlanAggregateRoot? GetSubscriptionPlanBySlug(string slug);
    }
}
