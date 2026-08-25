using JobPortal.Shared.Interfaces.CommandHandler;
using SubscriptionPlan.DTO.Command;

namespace SubscriptionPlan.Handler.CommandHandler
{
    public class RegisterSubscriptionHandler : ICommandHandler<RegisterSubscriptionCommand>
    {
        public Task HandleAsync(RegisterSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
