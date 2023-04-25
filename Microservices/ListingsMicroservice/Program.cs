using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9005
builder.WebHost.UseUrls("http://*:9005");
builder.Host.UseSerilog(SeriLogger.Configure);
builder.Configuration.AddJsonFile("Properties/appsettings.json");

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerWithConfig("Listings")
    .AddRepositories()
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider(builder)
    .AddHealthChecks();
//  .AddMediatR(typeof(MediatREntryPoint).Assembly)
//  .AddServices();

var app = builder.Build();
app.AddSwaggerDevelopmentDocs("Listings");
app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();
app.MapHealthCheckEndpoint();
app.Run();
