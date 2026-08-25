using JobPortal.Shared.Interfaces.CommandHandler;
using SubscriptionPlan.DTO.Command;

namespace SubscriptionPlan.Handler.CommandHandler
{
    internal class UpdateSubscriptionHandler : ICommandHandler<UpdateSubscriptionCommand>
    {
        public Task HandleAsync(UpdateSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
