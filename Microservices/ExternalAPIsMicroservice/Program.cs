using ExternalAPIsMicroservice.Properties;
using RealEstate.ApiGateway.Properties;
using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9004
builder.WebHost.UseUrls("http://*:9004");
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddRepositoriesAndContexts()
    .AddSwaggerWithConfig("External")
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider()
    .AddStripeInfrastructure(builder.Configuration)
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly))
    .AddHealthChecks();

var app = builder.Build();

app.UseSwaggerDevelopmentDocs("External");
app.UseAuthentication().UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");
ConsoleMessageUtil.MicroserviceStartupMessage("External APIs");
app.Run();
