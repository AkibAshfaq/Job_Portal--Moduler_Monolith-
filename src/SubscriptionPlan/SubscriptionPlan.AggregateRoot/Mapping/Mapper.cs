using SubscriptionPlan.AggregateRoot.Mapping.Interface;
using SubscriptionPlan.DTO.Command;
using SubscriptionPlan.DTO.Query;
using SubscriptionPlan.DTO.Response;

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

        public IEnumerable<ViewSubscriptionResponse> EntityToResponse(IEnumerable<SubscriptionPlanAggregateRoot> entities)
        {
            return entities.Select(entity => new ViewSubscriptionResponse
            {
                Name = entity.Name,
                Slug = entity.Slug,
                Description = entity.Description,
                Price = entity.Price,
                Currency = entity.Currency,
                DurationDays = entity.DurationDays,
                JobPostLimit = entity.JobPostLimit,
                FeaturedJobLimit = entity.FeaturedJobLimit,
                ResumeViewLimit = entity.ResumeViewLimit,
                CanSearchResumes = entity.CanSearchResumes,
                HasPrioritySupport = entity.HasPrioritySupport,
                IsActive = entity.IsActive
            }).ToList();
        }
    }
}
