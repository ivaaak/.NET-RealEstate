using ListingsMicroservice.Properties;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9005
builder.WebHost.UseUrls("http://*:9005");

builder.Services
    .AddSwaggerWithConfig()
    .AddServices();
    //.Use_PostgreSQL_Listings_Context(builder.Configuration);
    //.AddMediatR(typeof(MediatREntryPoint).Assembly); //Reference to the MediatR Assembly

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}

app.UseHttpsRedirection().UseAuthorization().UseAuthentication();
app.MapControllers();

app.Run();
