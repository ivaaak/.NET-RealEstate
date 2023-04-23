using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace RealEstate.Shared.ServiceExtensions.Swagger
{
    /// <summary>
    /// Configure the Swagger generator.
    /// </summary>
    public static class ConfigureSwaggerSwashbuckle
    {
        /// <summary>
        /// Configure the Swagger generator with XML comments, bearer authentication, etc.
        /// Additional configuration files:
        /// <list type="bullet">
        ///     <item>ConfigureSwaggerSwashbuckleOptions.cs</item>
        /// </list>
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerSwashbuckleConfigured(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerSwashbuckleOptions>();

            // Configures ApiExplorer (needed from ASP.NET Core 6.0).
            services.AddEndpointsApiExplorer();

            // Register the Swagger generator, defining one or more Swagger documents.
            // Read more here: https://github.com/domaindrivendev/Swashbuckle.AspNetCore
            services.AddSwaggerGen(options =>
            {
                // If we would like to provide request and response examples (Part 1/2)
                // Enable the Automatic (or Manual) annotation of the [SwaggerRequestExample] and [SwaggerResponseExample].
                // Read more here: https://github.com/mattfrear/Swashbuckle.AspNetCore.Filters
                options.ExampleFilters();

                // If we would like to include documentation comments in the OpenAPI definition file and SwaggerUI.
                // Set the comments path for the XmlComments file.
                // Read more here: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio#xml-comments
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath, true);

                // If we would like to provide security information about the authorization scheme that we are using (e.g. Bearer).
                // Add Security information to each operation for bearer tokens and define the scheme.
                options.OperationFilter<SecurityRequirementsOperationFilter>(true, "Bearer");
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (JWT). Example: \"bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // If we use the [Authorize] attribute to specify which endpoints require Authorization, then we can
                // Show an "(Auth)" info to the summary so that we can easily see which endpoints require Authorization.
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            });

            // If we would like to provide request and response examples (Part 2/2)
            // Register examples with the ServiceProvider based on the location assembly or example type.
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            // If we are using FluentValidation, then we can register the following service to add the  fluent validation rules to swagger.
            // Adds FluentValidationRules staff to Swagger. (Minimal configuration)

            //services.AddFluentValidationRulesToSwagger();s
        }
    }
}
