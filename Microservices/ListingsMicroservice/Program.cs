using ListingsMicroservice.Properties;
using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9005
builder.WebHost.UseUrls("http://*:9005");
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddRepositoriesAndContexts(builder.Configuration)
    .AddSwaggerWithConfig("Contracts")
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider(builder)
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly))
    .AddHealthChecks();

var app = builder.Build();

app.AddSwaggerDevelopmentDocs("Listings");
app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
