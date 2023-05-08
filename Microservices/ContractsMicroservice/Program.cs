using ContractsMicroservice.Data.Context;
using ContractsMicroservice.Services;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9002
builder.WebHost.UseUrls("http://*:9002");
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddTransient<IDocumentService, DocumentService>();
builder.Services.AddTransient<IContractsDbRepository, ContractsDbRepository>();
builder.Services.AddDbContext<ContractsDBContext>();
builder.Services.AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerWithConfig("Contracts")
    .AddRepositories()
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider(builder)
    .AddHealthChecks();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();
app.AddSwaggerDevelopmentDocs("Contracts");
app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();
app.MapHealthCheckEndpoint();
app.Run();