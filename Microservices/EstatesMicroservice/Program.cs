using EstatesMicroservice.Properties;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9003
builder.WebHost.UseUrls("http://*:9003");

builder.Services
    .AddSwaggerWithConfig();
    //.AddMediatR(typeof(MediatREntryPoint).Assembly);
    //.AddServices()
    //.Use_PostgreSQL_Estates_Context(builder.Configuration);

builder.Services.AddControllers();

builder.Configuration.AddJsonFile("Properties/appsettings.json");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estates MS v1"));
}

app.UseHttpsRedirection().UseAuthorization().UseAuthentication();

app.MapControllers();

app.Map("/hc", builder =>
{
    builder.UseHealthChecks("/hc", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

app.Run();
