using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using RealEstate.API.ServiceExtensions;
using RealEstate.CQRS;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Use_PostgreSQL_Context(builder.Configuration);
//builder.Services.Add_MicrosoftSQL_Context(builder.Configuration);
builder.Services.AddAuth0Authentication(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.AddIdentityContext();
builder.Services.AddJWTAuthentication();
//builder.Services.AddHangfire();
builder.Services.AddHangfireWithPostgreSQLServer(builder.Configuration);
builder.Services.AddModelBinders();
builder.Services.AddApplicationServices();
builder.Services.AddApiVersioningConfigured();
builder.Services.AddMediatR(typeof(MediatREntryPoint).Assembly); //Reference to the CQRS Assembly

var app = builder.Build();

// App routing
app.UseHttpsRedirection().UseStaticFiles();
app.UseRouting();
app.UseAuthentication().UseAuthorization();
app.UseHangfireDashboard();

app.MapControllerRoute(name: "Area", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve the generated OpenAPI definition as JSON files.
    app.UseSwagger();

    // Enable middleware to serve Swagger-UI (HTML, JS, CSS, etc.) by specifying the Swagger JSON endpoint(s).
    var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwaggerUI(options =>
    {
        // Build a swagger endpoint for each discovered API version
        foreach (var description in descriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

//var developmentFlag = app.Environment.IsDevelopment() ? app.UseMigrationsEndPoint() : app.UseExceptionHandler("/Home/Error");

app.Run();