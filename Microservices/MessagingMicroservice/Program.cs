using MessagingMicroservice.Properties;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9006
builder.WebHost.UseUrls("http://*:9006");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}

app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();

app.Run();
