using SubscriptionPlan.AggregateRoot.Mapping.Interface;
using SubscriptionPlan.DTO.Command;
using SubscriptionPlan.DTO.Query;

namespace SubscriptionPlan.AggregateRoot.Mapping
{
    public class Mapper : IMapper
    {
        public Mapper() { }

        public SubscriptionPlanAggregateRoot RegisterRequestToEntity(RegisterSubscriptionCommand request)
        {
            return new SubscriptionPlanAggregateRoot {
                Name = request.Name,
                Slug = request.Slug,
                Description = request.Description,
                Price = request.Price,
                Currency = request.Currency,
                DurationDays = request.DurationDays,
                JobPostLimit = request.JobPostLimit,
                FeaturedJobLimit = request.FeaturedJobLimit,
                ResumeViewLimit = request.ResumeViewLimit,
                CanSearchResumes = request.CanSearchResumes,
                HasPrioritySupport = request.HasPrioritySupport,
                IsActive = request.IsActive,
                CreatedAt=DateTime.UtcNow
            };
        }

        public SubscriptionPlanAggregateRoot UpdateRequestToEntity(UpdateSubscriptionCommand request)
        {
            return new SubscriptionPlanAggregateRoot
            {
                Name = request.Name,
                Slug = request.Slug,
                Description = request.Description,
                Price = request.Price,
                Currency = request.Currency,
                DurationDays = request.DurationDays,
                JobPostLimit = request.JobPostLimit,
                FeaturedJobLimit = request.FeaturedJobLimit,
                ResumeViewLimit = request.ResumeViewLimit,
                CanSearchResumes = request.CanSearchResumes,
                HasPrioritySupport = request.HasPrioritySupport,
                IsActive = request.IsActive,
                UpdatedAt = DateTime.UtcNow,
            };
        }

        public SubscriptionPlanAggregateRoot RemoveRequestToEntity(RemoveSubscriptionCommand request)
        {
            return new SubscriptionPlanAggregateRoot
            {
                Name = request.Name,
                Slug = request.Slug
            };
        }

        public SubscriptionPlanAggregateRoot GetRequestToEntity(ViewSubscriptionQuery request)
        {
            return new SubscriptionPlanAggregateRoot
            {
                Name = request.Name,
                Slug = request.Slug
            };
        }
    }
}
