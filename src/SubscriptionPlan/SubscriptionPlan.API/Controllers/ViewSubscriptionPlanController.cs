using JobPortal.Shared.Interfaces.QueryHandler;
using Microsoft.AspNetCore.Mvc;
using SubscriptionPlan.DTO.Query;
using SubscriptionPlan.DTO.Response;

namespace SubscriptionPlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewSubscriptionPlanController : ControllerBase
    {
        private readonly IQueryHandler<ViewSubscriptionQuery, IEnumerable<ViewSubscriptionResponse>> _queryHandler;    
        public ViewSubscriptionPlanController( 
            IQueryHandler<ViewSubscriptionQuery, IEnumerable<ViewSubscriptionResponse>> queryHandler)
        {
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ViewSubscriptionPlan()
        {
            return Ok( await _queryHandler.HandleAsync(null));
        }
    }
}
