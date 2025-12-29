using System.Net;
using System.Text.Json;

namespace boxer_assessment.Middleware
{
    /// <summary>
    /// Middleware for handling unhandled exceptions.
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        /// <summary>
        /// Next middleware in the pipeline.
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Creates a new exception middleware instance.
        /// </summary>
        /// <param name="next">Next middleware.</param>
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Executes the middleware.
        /// </summary>
        /// <param name="context">HTTP context.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    message = "An unexpected error occurred."
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response));
            }
        }
    }
}
