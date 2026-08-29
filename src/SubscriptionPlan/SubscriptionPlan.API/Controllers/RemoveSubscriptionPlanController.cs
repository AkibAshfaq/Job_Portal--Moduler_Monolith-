using JobPortal.Shared.Interfaces.CommandHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubscriptionPlan.DTO.Command;

namespace SubscriptionPlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveSubscriptionPlanController : ControllerBase
    {
        private readonly ICommandHandler<RemoveSubscriptionCommand> _commandHandler;
        public RemoveSubscriptionPlanController(ICommandHandler<RemoveSubscriptionCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSubscriptionPlan(RemoveSubscriptionCommand command)
        {
            await _commandHandler.HandleAsync(command);
            return Ok("Subscription plan removed successfully.");
        }
    }
}
