using SubscriptionPlan.AggregateRoot;
using SubscriptionPlan.Repository.Context;
using SubscriptionPlan.Repository.Repositories.Interfaces;

namespace SubscriptionPlan.Repository.Repositories
{
    public class SubscriptionPlanRepository : GenericRepository<SubscriptionPlanAggregateRoot>, ISubscriptionPlanRepository
    {
        public SubscriptionPlanRepository(PortalDbContext context) : base(context) {}
        public SubscriptionPlanAggregateRoot? GetSubscriptionPlanBySlug(string slug)
        {
            return _dbset.FirstOrDefault(s => s.Slug == slug);
        }
    }
}
