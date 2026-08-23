using Microsoft.AspNetCore.Mvc;
using UserManagment.AggregateRoot.Entities;
using UserManagment.DTO.DTO;
using UserManagment.DTO.Query;
using UserManagment.Handler.Abstractions;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUsersController : ControllerBase
    {
        private readonly IQueryHandler<GetUsersQuery, IEnumerable<User>> getUsersHandler;

        public GetUsersController(IQueryHandler<GetUsersQuery, IEnumerable<User>> getUsersHandler)
        {
            this.getUsersHandler = getUsersHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return Ok(await getUsersHandler.HandleAsync(null));
        }
    }
}
