using Microsoft.AspNetCore.Mvc;

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
