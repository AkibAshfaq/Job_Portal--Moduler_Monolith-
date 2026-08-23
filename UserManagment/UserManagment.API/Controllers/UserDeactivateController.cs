using Microsoft.AspNetCore.Mvc;
using UserManagment.DTO.Command;
using UserManagment.Handler.Abstractions;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDeactivateController : ControllerBase
    {
        private readonly ICommandHandler<UserDeleteCommand> _handler;
        public UserDeactivateController(ICommandHandler<UserDeleteCommand> handler)
        {
            _handler = handler;
        }
        [HttpDelete()]
        public async Task<IActionResult> DeactivateUser(UserDeleteCommand command)
        {
            await _handler.HandleAsync(command);
            return Ok(new { Message = "User removed successfully" });
        }
    }
}
