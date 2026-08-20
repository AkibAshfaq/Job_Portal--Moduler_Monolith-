using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagment.DTO.UserRequestDTO;
using UserManagment.Handler.CommandHandlers;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        private readonly UserRegistrationHandler _userRegistrationHandler;
        public UserRegisterController(UserRegistrationHandler userRegistrationHandler)
        {
            _userRegistrationHandler = userRegistrationHandler;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRegisterRequest request)
        {
            return Ok(_userRegistrationHandler.RegisterUserAsync(request));
            //return Ok(new { Message = "User created successfully" });
        }
    }
}
