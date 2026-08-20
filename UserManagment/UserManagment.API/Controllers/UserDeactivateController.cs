using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagment.DTO.UserRequestDTO;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDeactivateController : ControllerBase
    {
        [HttpPut("{Id:int}")]
        public async Task<IActionResult> DeactivateUser(int Id)
        {
            return Ok(new { Message = "User removed successfully" });
        }
    }
}
