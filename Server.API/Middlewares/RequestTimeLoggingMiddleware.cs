using System.Diagnostics;

namespace Server.API.Middlewares;

public class RquestTimeLoggingMiddleware : IMiddleware
{
    ILogger<RquestTimeLoggingMiddleware> _logger;

    public RquestTimeLoggingMiddleware(ILogger<RquestTimeLoggingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopWatch = Stopwatch.StartNew();

        await next.Invoke(context);

        stopWatch.Stop();

        if (stopWatch.ElapsedMilliseconds / 1000 > 4) 
        {
            _logger.LogInformation($"Request {context.Request.Method} at {context.Request.Path} took {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}
