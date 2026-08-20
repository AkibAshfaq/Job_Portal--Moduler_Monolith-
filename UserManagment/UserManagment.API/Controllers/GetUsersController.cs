using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagment.Handler.QueryHandler;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUsersController : ControllerBase
    {
        private readonly GetUsersHandler _getUsersHandler;
        public GetUsersController(GetUsersHandler getUsersHandler)
        {
            _getUsersHandler = getUsersHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _getUsersHandler.Handler();
            return Ok(users);
        }
    }
}
