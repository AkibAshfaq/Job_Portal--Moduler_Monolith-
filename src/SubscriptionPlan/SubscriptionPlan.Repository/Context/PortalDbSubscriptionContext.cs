using Microsoft.EntityFrameworkCore;
using SubscriptionPlan.AggregateRoot;

namespace SubscriptionPlan.Repository.Context
{
    public class PortalDbSubscriptionContext : DbContext
    {
        public PortalDbSubscriptionContext(DbContextOptions<PortalDbSubscriptionContext> options) : base(options) { }

        public DbSet<SubscriptionPlanAggregateRoot> SubscriptionPlans => Set<SubscriptionPlanAggregateRoot>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortalDbSubscriptionContext).Assembly);
        }
    }
}
