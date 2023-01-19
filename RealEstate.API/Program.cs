using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using RealEstate.API.ServiceExtensions;
using RealEstate.CQRS;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddServicesFactory()
    .Use_PostgreSQL_Context(builder.Configuration)
    .AddAuth0Authentication(builder.Configuration)
    .AddAutoMapper()
    .AddIdentityContext()
    .AddJWTAuthentication()
    .AddHangfireWithPostgreSQLServer(builder.Configuration)
    .AddModelBinders()
    .AddApiVersioningConfigured()
    .AddMediatR(typeof(MediatREntryPoint).Assembly); //Reference to the CQRS Assembly
    //.Use_MicrosoftSQL_Context(builder.Configuration);
    //.AddHangfire();

var app = builder.Build();

// App routing
app.UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization()
    .UseHangfireDashboard();

app.MapControllers();
app.MapControllerRoute(name: "Area", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");

if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve the generated OpenAPI definition as JSON files.
    app.UseSwagger();

    // Enable middleware to serve Swagger-UI (HTML, JS, CSS, etc.) by specifying the Swagger JSON endpoint(s).
    var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger(options =>
    {
        // Build a swagger endpoint for each discovered API version
        foreach (var description in descriptionProvider.ApiVersionDescriptions)
        {
            //options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

//var developmentFlag = app.Environment.IsDevelopment() ? app.UseMigrationsEndPoint() : app.UseExceptionHandler("/Home/Error");

app.Run();



/*
TODO: optimise for Autofac DI ?
    builder.Host.UseServiceProviderFactory(new DependencyFactory());
    // Type Registrations
    builder.RegisterType<DependencyFactory>().As<IDependencyFactory>().SingleInstance();
    builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MyApplicationModule()));
 */