using ClientsMicroservice.Data.Context;
using ClientsMicroservice.Data.Repository;
using ClientsMicroservice.Services;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:9001");  // Run on port 9001
builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddDbContext<UsersDBContext>();
builder.Services.AddDbContext<ClientsDBContext>();

builder.Services.AddScoped<IClientsDbRepository, ClientsDbRepository>();

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerWithConfig("Clients")
    .AddRepositories()
    .AddRedisCacheWithConnectionString(builder)
    .AddMassTransitWithRabbitMQProvider(builder)
    .AddHealthChecks();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();
app.AddSwaggerDevelopmentDocs("Clients");

app.UseAuthentication().UseAuthorization();
app.MapControllers();
app.MapHealthCheckEndpoint();

app.Run();
