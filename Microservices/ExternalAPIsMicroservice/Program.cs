using ExternalAPIsMicroservice.Services;
using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9004
builder.WebHost.UseUrls("http://*:9004");
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IScraperService, ScraperService>();
builder.Services.AddControllers();
builder.Services.AddStripeInfrastructure(builder.Configuration);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerWithConfig("External")
    .AddRepositories()
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider(builder)
    .AddHealthChecks();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();
app.AddSwaggerDevelopmentDocs("External");
app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();
app.MapHealthCheckEndpoint();
app.Run();
