using System.Net;

namespace boxer_assessment.Middleware
{
    /// <summary>
    /// Middleware for API key authentication.
    /// </summary>
    public class ApiKeyMiddleware
    {
        /// <summary>
        /// HTTP header name for the API key.
        /// </summary>
        private const string ApiKeyHeaderName = "X-API-KEY";

        /// <summary>
        /// Next middleware in the pipeline.
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Configured API key value.
        /// </summary>
        private readonly string _apiKey;

        /// <summary>
        /// Creates a new API key middleware instance.
        /// </summary>
        /// <param name="next">Next middleware.</param>
        /// <param name="configuration">Application configuration.</param>
        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _apiKey = configuration["Authentication:ApiKey"]!;
        }

        /// <summary>
        /// Processes the HTTP request.
        /// </summary>
        /// <param name="context">HTTP context.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Options)
            {
                await _next(context);
                return;
            }

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
