using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SubscriptionPlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewSubscriptionPlanController : ControllerBase
    {
        public ViewSubscriptionPlanController() { }

        public IActionResult ViewSubscriptionPlan()
        {
            return Ok("Subscription plan details retrieved successfully.");
        }
    }
}
