using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SubscriptionPlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveSubscriptionPlanController : ControllerBase
    {
        public RemoveSubscriptionPlanController() { }

        public IActionResult RemoveSubscriptionPlan()
        {
            return Ok("Subscription plan removed successfully.");
        }
    }
}
