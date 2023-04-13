using ClientsMicroservice.Properties;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using RealEstate.Shared.MediatR;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9001
builder.WebHost.UseUrls("http://*:9001");

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerWithConfig()
    .AddMediatR(typeof(MediatREntryPoint).Assembly);

builder.Configuration.AddJsonFile("Properties/appsettings.json");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clients MS v1"));
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
