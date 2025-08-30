
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRateLimiter(configureOptions =>
{
    configureOptions.AddFixedWindowLimiter("fixed", RateLimiter =>
       {
           RateLimiter.PermitLimit = 2; // Allow 2 requests
           RateLimiter.Window = TimeSpan.FromSeconds(10); // Within a 10-second window

           RateLimiter.QueueLimit = 0; // No queueing, extra requests are rejected immediately.
       });

    configureOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests; // Set status code for rejected requests
});

var app = builder.Build();

app.UseRateLimiter();
app.UseRequestResponseLogging();

app.MapGet("/api/resources", () => "This api resource is rate limited")
.RequireRateLimiting("fixed");




app.Run();
