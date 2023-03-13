using ContractsMicroservice.Properties;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9002
builder.WebHost.UseUrls("http://*:9002");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithConfig();

builder.Configuration.AddJsonFile("Properties/appsettings.json");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}

app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();

app.Run();
