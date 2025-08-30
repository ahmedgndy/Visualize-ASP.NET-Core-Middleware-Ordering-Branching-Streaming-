public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }



 public async Task InvokeAsync(HttpContext context)
 {
     // Log request information
     _logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);

     // Call the next middleware in the pipeline
     await _next(context);

     // Log response information
     _logger.LogInformation("Finished handling request: {Method} {Path}", context.Request.Method, context.Request.Path);
 }
}
