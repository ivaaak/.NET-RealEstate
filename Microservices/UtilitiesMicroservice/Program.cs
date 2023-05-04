using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;
using UtilitiesMicroservice.Services.Cache;
using UtilitiesMicroservice.Services.CloudinaryService;
using UtilitiesMicroservice.Services.FileUpload;
using UtilitiesMicroservice.Services.Serializer;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9007
builder.WebHost.UseUrls("http://*:9007");
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddTransient<ICacheService, CacheService>();
builder.Services.AddTransient<ICloudinaryService, CloudinaryService>();
builder.Services.AddTransient<IFileUploadService, FileUploadService>();
builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerWithConfig("Utilities")
    .AddRepositories()
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider(builder)
    .AddHealthChecks();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();
app.AddSwaggerDevelopmentDocs("Utilities");
app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();
app.MapHealthCheckEndpoint();
app.Run();
