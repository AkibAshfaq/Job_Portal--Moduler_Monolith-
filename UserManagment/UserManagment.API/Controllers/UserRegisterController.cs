using Microsoft.AspNetCore.Mvc;
using UserManagment.DTO.Command;
using UserManagment.Handler.Abstractions;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        private readonly ICommandHandler<UserRegisterCommand> _userRegistrationHandler;
        public UserRegisterController(ICommandHandler<UserRegisterCommand>  userRegistrationHandler)
        {
            _userRegistrationHandler = userRegistrationHandler;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRegisterCommand request)
        {
            if (request == null) return BadRequest();
            await _userRegistrationHandler.HandleAsync(request);
            return Ok();
        }
    }
}
