using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;

namespace RealEstate.Shared.Logging
{
    public static class ApplicationLogger
    {
        public static void ConfigureLogger(this ConfigureHostBuilder host)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(
                    outputTemplate: "[{Level:u4}] |{SourceContext,30}({EventId})| {Message:lj}{NewLine}{Exception}",
                    restrictedToMinimumLevel: LogEventLevel.Debug)
                .CreateBootstrapLogger();

            host.UseSerilog();
        }
    }
}
