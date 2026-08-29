using JobPortal.Shared.Interfaces.CommandHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubscriptionPlan.DTO.Command;

namespace SubscriptionPlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateSubscriptionPlanController : ControllerBase
    {
        private readonly ICommandHandler<UpdateSubscriptionCommand> _commandHandler;
        public UpdateSubscriptionPlanController(ICommandHandler<UpdateSubscriptionCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubscriptionPlan(UpdateSubscriptionCommand command)
        {
            await _commandHandler.HandleAsync(command);
            return Ok("Subscription plan updated successfully.");
        }

    }
}
