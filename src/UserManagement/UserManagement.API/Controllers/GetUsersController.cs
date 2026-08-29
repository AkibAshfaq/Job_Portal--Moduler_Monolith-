using JobPortal.Shared.Interfaces.QueryHandler;
using Microsoft.AspNetCore.Mvc;
using UserManagement.AggregateRoot;
using UserManagement.DTO.DTO;
using UserManagement.DTO.Query;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUsersController : ControllerBase
    {
        private readonly IQueryHandler<GetUsersQuery, IEnumerable<UsersAggregateRoot>> getUsersHandler;

        public GetUsersController(IQueryHandler<GetUsersQuery, IEnumerable<UsersAggregateRoot>> getUsersHandler)
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
