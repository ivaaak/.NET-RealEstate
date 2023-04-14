using ClientsMicroservice.Properties;
using MediatR;
using RealEstate.Shared.Logging;
using RealEstate.Shared.MediatR;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:9001");  // Run on port 9001
builder.Host.UseSerilog(SeriLogger.Configure);
builder.Configuration.AddJsonFile("Properties/appsettings.json");

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerWithConfig()
    .AddRepositoryAndServices()
    .AddMediatR(typeof(MediatREntryPoint).Assembly)
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider(builder);

var app = builder.Build();
app.AddSwaggerDevelopmentDocs();
app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();
app.MapHealthCheckEndpoint();
app.Run();
