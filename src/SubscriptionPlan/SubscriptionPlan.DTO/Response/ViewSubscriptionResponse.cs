
namespace SubscriptionPlan.DTO.Response
{
    public class ViewSubscriptionResponse
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public int DurationDays { get; set; }
        public int JobPostLimit { get; set; }
        public int FeaturedJobLimit { get; set; }
        public int ResumeViewLimit { get; set; }
        public bool CanSearchResumes { get; set; }
        public bool HasPrioritySupport { get; set; }
        public bool IsActive { get; set; }
    }
}
