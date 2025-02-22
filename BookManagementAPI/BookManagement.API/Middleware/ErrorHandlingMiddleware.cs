using BookManagement.Application.Exceptions;
namespace BookManagementAPI.BookManagement.API.Middleware
{
    // ErrorHandlingMiddleware.cs
    public class ErrorHandlingMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ConflictException ex)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsJsonAsync(new { error = ex.Message });
            }
        }
    }
}
