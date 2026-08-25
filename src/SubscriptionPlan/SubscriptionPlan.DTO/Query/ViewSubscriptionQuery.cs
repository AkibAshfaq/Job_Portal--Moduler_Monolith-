using JobPortal.Shared.Interfaces.Query;

namespace SubscriptionPlan.DTO.Query
{
    public class ViewSubscriptionQuery : IQuery
    {
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
}
