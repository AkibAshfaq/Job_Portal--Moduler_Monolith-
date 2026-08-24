using Microsoft.AspNetCore.Mvc;
using LoginManagement.DTO.Commands;

namespace LoginManagemant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            if (request.username == "admin" && request.password == "password")
            {
                return Ok(new { Token = "your_generated_token_here" });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
