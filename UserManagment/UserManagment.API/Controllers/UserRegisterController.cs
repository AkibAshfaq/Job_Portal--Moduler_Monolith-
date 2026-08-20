using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagment.DTO.UserRequestDTO;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRegisterRequest request)
        {
            return Ok(new { Message = "User created successfully" });
        }
    }
}
