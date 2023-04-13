using HealthChecks.UI.Client;
using ListingsMicroservice.Properties;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using RealEstate.Shared.MediatR;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9005
builder.WebHost.UseUrls("http://*:9005");

builder.Services
    .AddSwaggerWithConfig()
    .AddServices()
    .AddMediatR(typeof(MediatREntryPoint).Assembly);
    //.Use_PostgreSQL_Listings_Context(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Listings MS v1"));
}

app.UseHttpsRedirection().UseAuthorization().UseAuthentication();

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
