using MediatR;
using RealEstate.CQRS;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiDbContexts(builder.Configuration);
builder.Services.AddApiServices();
builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(MediatREntryPoint).Assembly); //Reference to the CQRS Assembly

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
