using Microsoft.AspNetCore.Mvc;
using UserManagment.DTO.Command;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUpdateController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateCommand request)
        {
            return Ok(new { Message = "User updated successfully" });
        }
    }
}
