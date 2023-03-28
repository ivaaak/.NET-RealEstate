using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using UtilitiesMicroservice.Properties;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9007
builder.WebHost.UseUrls("http://*:9007");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer().AddSwaggerWithConfig();

var app = builder.Build();

// ADD HANGFIRE SERVICE EXTENSION

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Utilities MS v1"));
}

app.UseHttpsRedirection().UseAuthorization();

app.MapControllers();

app.Map("/hc", builder =>
{
    builder.UseHealthChecks("/hc", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

app.Run();
