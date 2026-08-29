using JobPortal.Shared.Interfaces.CommandHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubscriptionPlan.DTO.Command;
using System.Windows.Input;

namespace SubscriptionPlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterSubscriptionPlanController : ControllerBase
    {
        private readonly ICommandHandler<RegisterSubscriptionCommand> _commandHandler;
        public RegisterSubscriptionPlanController(ICommandHandler<RegisterSubscriptionCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterSubscriptionPlan(RegisterSubscriptionCommand command)
        {
            await _commandHandler.HandleAsync(command);
            return Ok("Subscription plan registered successfully.");
        }
    }
}
