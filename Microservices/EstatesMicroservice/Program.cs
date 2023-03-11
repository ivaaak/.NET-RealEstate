using EstatesMicroservice.Properties;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Shared.MediatR;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9003
builder.WebHost.UseUrls("http://*:9003");

builder.Services
    //.AddSwaggerGen()
    .AddServices()
    .Use_PostgreSQL_Estates_Context(builder.Configuration);
    //.AddMediatR(typeof(MediatREntryPoint).Assembly); //Reference to the MediatR Assembly

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}

app.UseHttpsRedirection().UseAuthorization().UseAuthentication();
app.MapControllers();

app.Run();
