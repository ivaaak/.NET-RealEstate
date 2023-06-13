using EstatesMicroservice.Properties;
using RealEstate.ApiGateway.Properties;
using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9003
builder.WebHost.UseUrls("http://*:9003");
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddRepositoriesAndContexts(builder.Configuration)
    .AddSwaggerWithConfig("Estates")
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly))
    .AddHealthChecks();

var app = builder.Build();

app.UseSwaggerDevelopmentDocs("Estates");
app.UseAuthentication().UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");
ConsoleMessageUtil.MicroserviceStartupMessage("Estates");
app.Run();
