using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using RealEstate.ApiGateway.Authentication;
using RealEstate.ApiGateway.Authorization;
using RealEstate.ApiGateway.Properties;
using RealEstate.Shared.Logging;
using RealEstate.Shared.ServiceExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Configure API Gateway
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelotMicroservices.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Run the Gateway on port 9000
builder.WebHost.UseUrls("http://*:9000");
builder.Host.UseSerilog(SeriLogger.Configure); // Change to ApplicationLogger.ConfigureLogger ?

builder.Services.AddOcelot(builder.Configuration).AddCacheManager(s => s.WithDictionaryHandle());
builder.Services.AddTransient<LoggingDelegatingHandler>();
builder.Services.AddCors().AddEndpointsApiExplorer();
builder.Services.AddHealthCheckServices();
builder.Services.AddSwaggerWithConfig("API Gateway");
builder.Services.AddKeycloakAuthenticationConfigured(builder.Configuration);
builder.Services.AddKeycloakAuthorizationConfigured(builder.Configuration);

var app = builder.Build();

await app.UseOcelot();
app.UseCors();
app.AddSwaggerDevelopmentDocs("API Gateway");
app.UseHttpsRedirection();
app.UseApplicationSwagger(builder.Configuration);
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
