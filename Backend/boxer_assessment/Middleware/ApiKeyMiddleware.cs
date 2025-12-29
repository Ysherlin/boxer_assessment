using System.Net;

namespace boxer_assessment.Middleware
{
    /// <summary>
    /// Middleware for simple API key authentication.
    /// </summary>
    public class ApiKeyMiddleware
    {
        private const string ApiKeyHeaderName = "X-API-KEY";
        private readonly RequestDelegate _next;
        private readonly string _apiKey;

        /// <summary>
        /// Creates a new middleware instance.
        /// </summary>
        /// <param name="next">Next middleware.</param>
        /// <param name="configuration">Application configuration.</param>
        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _apiKey = configuration["Authentication:ApiKey"]!;
        }

        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="context">HTTP context.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var providedKey) ||
                providedKey != _apiKey)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            await _next(context);
        }
    }
}
