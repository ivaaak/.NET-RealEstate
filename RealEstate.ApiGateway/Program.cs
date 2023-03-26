using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using RealEstate.Shared.CrossCutting.Logging;

var builder = WebApplication.CreateBuilder(args);
// Configure API Gateway
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("GatewayConfigs/ocelotClientsConfig.json", optional: false, reloadOnChange: true)
    .AddJsonFile("GatewayConfigs/ocelotContractsConfig.json", optional: false, reloadOnChange: true)
    .AddJsonFile("GatewayConfigs/ocelotEstatesConfig.json", optional: false, reloadOnChange: true)
    .AddJsonFile("GatewayConfigs/ocelotExternalConfig.json", optional: false, reloadOnChange: true)
    .AddJsonFile("GatewayConfigs/ocelotListingsConfig.json", optional: false, reloadOnChange: true)
    .AddJsonFile("GatewayConfigs/ocelotMessagingConfig.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Run the Gateway on port 9000
builder.WebHost.UseUrls("http://*:9000");

builder.Services
    .AddOcelot(builder.Configuration);
    //.AddIdentityContext()
    //.AddUserService()
    //.AddJWTAuthService()
    //.AddJWTAuthentication()
    //.AddAuth0Authentication(builder.Configuration)
    //.AddApiVersioningConfigured()
    //.AddMediatR(typeof(MediatREntryPoint).Assembly); //Reference to the CQRS Assembly

builder.Services.AddTransient<LoggingDelegatingHandler>();

var app = builder.Build();

await app.UseOcelot();
// App routing
app.UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization();

app.Run();
