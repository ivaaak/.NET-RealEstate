using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;
using RealEstate.ApiGateway.Authentication;
using RealEstate.ApiGateway.Authorization;
using RealEstate.ApiGateway.Properties;
using RealEstate.Shared.Logging;

var builder = WebApplication.CreateBuilder(args);
// Configure API Gateway
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json")
    .AddEnvironmentVariables();

// Run the Gateway on port 9000
builder.WebHost.UseUrls("http://*:9000");
builder.AddSerilogElasticsearch();

builder.Services.AddOcelot(builder.Configuration).AddPolly().AddCacheManager(s => s.WithDictionaryHandle());
builder.Services.AddSwaggerForOcelot(builder.Configuration);
builder.Services.AddCors().AddEndpointsApiExplorer();

builder.Services.AddElasticClientAndLoggingDelegateHandler();
builder.Services.AddKeycloakAuthenticationConfigured(builder.Configuration);
builder.Services.AddKeycloakAuthorizationConfigured(builder.Configuration);

var app = builder.Build();

app.UseSwaggerForOcelotUI();
app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseOcelot().Wait();

ConsoleMessageUtil.APIGatewayStartupMessage();
app.Run();
