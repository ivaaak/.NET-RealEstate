using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using RealEstate.Shared.Logging;
using Serilog;
using System.Configuration;
using Keycloak.AuthServices.Authentication;
using RealEstate.ApiGateway.Authentication;

var builder = WebApplication.CreateBuilder(args);
// Configure API Gateway
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("GatewayConfigs/ocelotClientsConfig.json", optional: true, reloadOnChange: true)
    .AddJsonFile("GatewayConfigs/ocelotContractsConfig.json", optional: true, reloadOnChange: true)
    .AddJsonFile("GatewayConfigs/ocelotEstatesConfig.json", optional: true, reloadOnChange: true)
    .AddJsonFile("GatewayConfigs/ocelotExternalConfig.json", optional: true, reloadOnChange: true)
    .AddJsonFile("GatewayConfigs/ocelotListingsConfig.json", optional: true, reloadOnChange: true)
    .AddJsonFile("GatewayConfigs/ocelotMessagingConfig.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Run the Gateway on port 9000
builder.WebHost.UseUrls("http://*:9000");
builder.Host.UseSerilog(SeriLogger.Configure); // Change to ApplicationLogger.ConfigureLogger ?

builder.Services
    .AddOcelot(builder.Configuration)
    .AddCacheManager(settings => settings.WithDictionaryHandle());
builder.Services.AddTransient<LoggingDelegatingHandler>();
builder.Services.AddCors();

builder.Services.AddKeycloakAuthenticationConfigured(builder.Configuration);


var app = builder.Build();

await app.UseOcelot();
app.UseCors();

// App routing
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
