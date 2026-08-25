using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SubscriptionPlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterSubscriptionPlanController : ControllerBase
    {
        public RegisterSubscriptionPlanController() { }

        public IActionResult RegisterSubscriptionPlan()
        {
            return Ok("Subscription plan registered successfully.");
        }
    }
}
