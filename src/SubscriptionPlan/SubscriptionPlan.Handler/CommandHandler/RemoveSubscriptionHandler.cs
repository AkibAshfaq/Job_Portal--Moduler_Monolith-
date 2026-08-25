using JobPortal.Shared.Interfaces.CommandHandler;
using SubscriptionPlan.DTO.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SubscriptionPlan.Handler.CommandHandler
{
    public class RemoveSubscriptionHandler : ICommandHandler<RemoveSubscriptionCommand>
    {
        public Task HandleAsync(RemoveSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
