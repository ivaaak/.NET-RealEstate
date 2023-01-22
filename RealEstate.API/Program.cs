using Hangfire;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using RealEstate.API.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services
    .AddIdentityContext()
    .AddJWTAuthentication()
    .AddAuth0Authentication(builder.Configuration)
    .AddApiVersioningConfigured()
    .AddOcelot(builder.Configuration);
    //.AddServicesFactory()
    //.Use_PostgreSQL_Context(builder.Configuration)
    //.AddAutoMapper()
    //.AddHangfireWithPostgreSQLServer(builder.Configuration)
    //.AddModelBinders()
    //.AddMediatR(typeof(MediatREntryPoint).Assembly); //Reference to the CQRS Assembly
    //.Use_MicrosoftSQL_Context(builder.Configuration);
    //.AddHangfire();

var app = builder.Build();

await app.UseOcelot();
// App routing
app.UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization()
    .UseHangfireDashboard();
/*
app.MapControllers();
app.MapControllerRoute(name: "Area", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");
*/
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
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
*/
app.Run();


/*
TODO: optimise for Autofac DI ?
    builder.Host.UseServiceProviderFactory(new DependencyFactory());
    // Type Registrations
    builder.RegisterType<DependencyFactory>().As<IDependencyFactory>().SingleInstance();
    builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MyApplicationModule()));
 */