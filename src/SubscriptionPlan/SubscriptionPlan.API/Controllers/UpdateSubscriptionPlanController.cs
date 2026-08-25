using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SubscriptionPlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateSubscriptionPlanController : ControllerBase
    {
        public UpdateSubscriptionPlanController() { }

        public IActionResult UpdateSubscriptionPlan()
        {
            return Ok("Subscription plan updated successfully.");
        }

    }
}
