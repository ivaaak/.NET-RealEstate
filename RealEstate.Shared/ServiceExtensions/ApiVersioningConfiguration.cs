using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace RealEstate.Shared.ServiceExtensions
{
    /// <summary>
    /// Configure the API versioning properties of the project.
    /// </summary>
    public static class AddApiVersioningConfigured
    {
        /// <summary>
        /// Configure the API versioning properties of the project, such as return headers, version format, etc.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddApiVersioningConfiguration(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                // ReportApiVersions will return the "api-supported-versions" and "api-deprecated-versions" headers.
                options.ReportApiVersions = true;

                // Set a default version when it's not provided,
                // e.g., for backward compatibility when applying versioning on existing APIs
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);

                // Combine (or not) API Versioning Mechanisms:
                options.ApiVersionReader = ApiVersionReader.Combine(
                        // The Default versioning mechanism which reads the API version from the "api-version" Query String paramater.
                        new QueryStringApiVersionReader("api-version"),
                        // Use the following, if you would like to specify the version as a custom HTTP Header.
                        new HeaderApiVersionReader("Accept-Version"),
                        // Use the following, if you would like to specify the version as a Media Type Header.
                        new MediaTypeApiVersionReader("api-version")
                    );
            });

            // Support versioning on our documentation.
            services.AddVersionedApiExplorer(options =>
            {
                // Format the version as "v{Major}.{Minor}.{Patch}" (e.g. v1.0.0).
                options.GroupNameFormat = "'v'VVV";

                // Note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
