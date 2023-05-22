using MessagingMicroservice.Properties;
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
    .AddRepositoriesAndContexts()
    .AddSwaggerWithConfig("Messaging")
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly))
    .AddHealthChecks();

var app = builder.Build();

app.AddSwaggerDevelopmentDocs("Messaging");
app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
