using JobPortal.Shared.Interfaces.Command;

namespace SubscriptionPlan.DTO.Command
{
    public class RemoveSubscriptionCommand : ICommand
    {
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
}
