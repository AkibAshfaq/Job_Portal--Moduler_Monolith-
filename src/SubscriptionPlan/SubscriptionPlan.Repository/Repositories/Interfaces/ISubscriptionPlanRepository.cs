using SubscriptionPlan.AggregateRoot;


namespace SubscriptionPlan.Repository.Repositories.Interfaces
{
    public interface ISubscriptionPlanRepository : IGenericRepository<SubscriptionPlanAggregateRoot>
    {
        Task<SubscriptionPlanAggregateRoot?> GetSubscriptionPlanBySlug(string slug);
    }
}
