using Microsoft.AspNetCore.Mvc;
using UserManagment.DTO.UserRequestDTO;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUpdateController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest request)
        {
            return Ok(new { Message = "User updated successfully" });
        }
    }
}
