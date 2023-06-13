using ClientsMicroservice.Properties;
using RealEstate.ApiGateway.Properties;
using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9001
builder.WebHost.UseUrls("http://*:9001");  
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddRepositoriesAndContexts(builder.Configuration)
    .AddKeycloakClientConfigured(builder.Configuration)
    .AddSwaggerWithConfig("Clients")
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly))
    .AddHealthChecks();


var app = builder.Build();

app.UseSwaggerDevelopmentDocs("Clients");
app.UseAuthentication().UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");
ConsoleMessageUtil.MicroserviceStartupMessage("Clients");
app.Run();
