using JobPortal.Shared.Exceptions;

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
            }catch (NotFoundException ex)
            {
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync(ex.Message);
            }
            catch (DtoValidationException ex)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                context.Response.StatusCode = 401;
                return context.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                return  context.Response.WriteAsync($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
