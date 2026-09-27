using MessagingMicroservice.Properties;
using RealEstate.ApiGateway.Authentication;
using RealEstate.ApiGateway.Properties;
using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9006
builder.WebHost.UseUrls("http://*:9006");
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddKeycloakAuthenticationConfigured(builder.Configuration)
    .AddRepositoriesAndContexts()
    .AddSwaggerWithConfig("Messaging")
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly))
    .AddMediatRNotificationsConfigured()
    .AddHealthChecks();

var app = builder.Build();

app.UseSwaggerDevelopmentDocs("Messaging");
app.UseAuthentication().UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");
ConsoleMessageUtil.MicroserviceStartupMessage("Messaging");
app.Run();
