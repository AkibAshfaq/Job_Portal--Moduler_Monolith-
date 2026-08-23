using Microsoft.AspNetCore.Mvc;
using UserManagment.DTO.Command;
using UserManagment.Handler.Abstractions;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUpdateController : ControllerBase
    {
        private readonly ICommandHandler<UserUpdateCommand> _handler;
        public UserUpdateController(ICommandHandler<UserUpdateCommand> handler)
        {
            _handler = handler;
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateCommand request)
        {
            if (request == null) return BadRequest("Invalid request data");
            await _handler.HandleAsync(request);
            return Ok();
        }
    }
}
