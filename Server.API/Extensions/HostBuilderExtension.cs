using Serilog;
using Serilog.Events;

namespace Server.API.Extensions;

public static class HostBuilderExtension
{
    public static ConfigureHostBuilder AddLogging(this ConfigureHostBuilder host)
    {
        host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
        );

        return host;
    }
}
