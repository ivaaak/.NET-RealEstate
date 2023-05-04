using EstatesMicroservice.Services;
using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9003
builder.WebHost.UseUrls("http://*:9003");
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddControllers();
builder.Services.AddTransient<IEstateService, EstateService>(); // move this to its own collection/method
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerWithConfig("Estates")
    .AddRepositories()
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider(builder)
    .AddHealthChecks();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();
app.AddSwaggerDevelopmentDocs("Estates");
app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();
app.MapHealthCheckEndpoint();
app.Run();
