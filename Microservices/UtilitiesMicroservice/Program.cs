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
    app.UseSwagger().UseSwaggerUI();
}

app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();

app.Run();
