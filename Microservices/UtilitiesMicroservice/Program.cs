using RealEstate.ApiGateway.Properties;
using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;
using UtilitiesMicroservice.Properties;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9007
builder.WebHost.UseUrls("http://*:9007");
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddRepositoriesAndContexts()
    .AddSwaggerWithConfig("Utilities")
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly))
    .AddHealthCheckServices()
    .AddSwaggerWithSchemaOptions(builder.Configuration);

var app = builder.Build();

app.UseSwaggerDevelopmentDocs("Utilities");
app.MapAndUseMultipleHealthChecks("/health");
app.MapControllers();
ConsoleMessageUtil.MicroserviceStartupMessage("Utilities");
app.Run();
