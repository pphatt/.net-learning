using Server.API.Middlewares;

namespace Server.API.Extensions;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
    {
        // add error handling middleware.
        app.UseMiddleware<ErrorHandlingMiddleware>();

        // add request time logging middleware.
        app.UseMiddleware<RquestTimeLoggingMiddleware>();

        return app;
    }
}
