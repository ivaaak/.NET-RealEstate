var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiDbContexts(builder.Configuration);
builder.Services.AddApiServices();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
