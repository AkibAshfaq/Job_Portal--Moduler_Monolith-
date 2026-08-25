using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionPlan.AggregateRoot;

namespace SubscriptionPlan.Repository.Configurations
{
    public class SubscriptionPlanConfiguration : IEntityTypeConfiguration<SubscriptionPlanAggregateRoot>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPlanAggregateRoot> builder)
        {
            builder.HasKey(sp => sp.Id);
            builder.Property(sp => sp.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(sp => sp.Slug)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(sp => sp.Description)
                .HasMaxLength(250);
            builder.Property(sp => sp.Currency)
                .IsRequired()
                .HasMaxLength(3);
            builder.Property(sp => sp.Price)
                .IsRequired()
                .HasPrecision(18, 2);
            builder.Property(sp => sp.DurationDays)
                .IsRequired();
            builder.Property(sp => sp.JobPostLimit)
                .IsRequired();
            builder.Property(sp => sp.FeaturedJobLimit)
                .IsRequired();
            builder.Property(sp => sp.ResumeViewLimit)
                .IsRequired();
            builder.Property(sp => sp.CanSearchResumes)
                .IsRequired();
            builder.Property(sp => sp.HasPrioritySupport)
                .IsRequired();
            builder.Property(sp => sp.IsActive)
                .IsRequired();
            builder.Property(sp => sp.DisplayOrder)
                .IsRequired();
            builder.Property(sp => sp.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.HasIndex(sp => sp.Slug)
                .IsUnique();
        }
    }
}
