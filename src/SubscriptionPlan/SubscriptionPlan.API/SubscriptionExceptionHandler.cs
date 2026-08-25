namespace SubscriptionPlan.API
{
    public class SubscriptionExceptionHandler : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                next.Invoke(context);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                return context.Response.WriteAsync($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
