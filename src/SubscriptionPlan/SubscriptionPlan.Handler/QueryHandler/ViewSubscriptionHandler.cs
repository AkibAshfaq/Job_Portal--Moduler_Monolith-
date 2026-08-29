using JobPortal.Shared.Interfaces.QueryHandler;
using SubscriptionPlan.AggregateRoot;
using SubscriptionPlan.AggregateRoot.Mapping.Interface;
using SubscriptionPlan.DTO.Query;
using SubscriptionPlan.DTO.Response;
using SubscriptionPlan.Repository.Repositories.Interfaces;

namespace SubscriptionPlan.Handler.QueryHandler
{
    public class ViewSubscriptionHandler : IQueryHandler<ViewSubscriptionQuery, IEnumerable<ViewSubscriptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionPlanRepository _subRepo;
        private readonly SubscriptionPlanAggregateRoot _SubRoot;

        public ViewSubscriptionHandler(
            IMapper mapper,
            ISubscriptionPlanRepository subRepo,
            SubscriptionPlanAggregateRoot subRoot)
        {
            _mapper = mapper;
            _subRepo = subRepo;
            _SubRoot = subRoot;
        }
        public async Task<IEnumerable<ViewSubscriptionResponse>> HandleAsync(ViewSubscriptionQuery? query)
        {
            var subscriptionPlans = _subRepo.GetAllAsync();
            if (query == null)
            {
                var response = _mapper.EntityToResponse(subscriptionPlans.Result);
                return response;
            }
            else
            {
                var filteredPlans = subscriptionPlans.Result.Where(sp =>
                    (string.IsNullOrEmpty(query.Name) || sp.Name.Contains(query.Name, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(query.Slug) || sp.Slug.Equals(query.Slug, StringComparison.OrdinalIgnoreCase))
                ).ToList();
                var response = _mapper.EntityToResponse(filteredPlans);
                return response;
            }

        }
    }
}
