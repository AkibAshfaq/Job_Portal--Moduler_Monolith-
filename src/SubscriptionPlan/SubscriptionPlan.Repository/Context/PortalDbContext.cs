using Microsoft.EntityFrameworkCore;
using SubscriptionPlan.AggregateRoot;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionPlan.Repository.Context
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> options) : base(options) { }

        public DbSet<SubscriptionPlanAggregateRoot> SubscriptionPlans => Set<SubscriptionPlanAggregateRoot>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortalDbContext).Assembly);
        }
    }
}
