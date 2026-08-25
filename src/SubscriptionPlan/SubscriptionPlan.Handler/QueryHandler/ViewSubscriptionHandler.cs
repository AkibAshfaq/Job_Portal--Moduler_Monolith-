using JobPortal.Shared.Interfaces.QueryHandler;
using SubscriptionPlan.DTO.Query;
using SubscriptionPlan.DTO.Response;

namespace SubscriptionPlan.Handler.QueryHandler
{
    public class ViewSubscriptionHandler : IQueryHandler<ViewSubscriptionQuery, ViewSubscriptionResponse>
    {
        public Task<ViewSubscriptionResponse> HandleAsync(ViewSubscriptionQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
