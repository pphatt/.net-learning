using Serilog;
using Serilog.Events;

namespace Server.API.Extensions;

public static class HostBuilderExtension
{
    public static ConfigureHostBuilder AddLogging(this ConfigureHostBuilder host)
    {
        host.UseSerilog((context, configuration) =>
            configuration
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM-yyyy HH:mm:ss} {Level:u3}] [{SourceContext}]{NewLine}{Message:lj}{NewLine}{Exception}")
        );

        return host;
    }
}
