using EstatesMicroservice.Properties;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9003
builder.WebHost.UseUrls("http://*:9003");

builder.Services
    .AddSwaggerWithConfig();
    //.AddServices()
    //.Use_PostgreSQL_Estates_Context(builder.Configuration);
//.AddMediatR(typeof(MediatREntryPoint).Assembly); //Reference to the MediatR Assembly

// inability to resolve the dependency for _CombinedContext

builder.Configuration.AddJsonFile("Properties/appsettings.json");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}

app.UseHttpsRedirection().UseAuthorization().UseAuthentication();
app.MapControllers();

app.Run();
