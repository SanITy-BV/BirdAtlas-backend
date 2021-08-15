using System;
using System.IO;
using BirdAtlas.Api.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BirdAtlas.Api.ConfigurationExtensions
{
    /// <summary>
    /// Extension methods on <see cref="IApplicationBuilder"/> and <see cref="IServiceCollection"/>
    /// for Swagger / OpenAPI documentation.
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Add Swagger as OpenAPI documentation tool.
        /// Uses API versioning configured through <see cref="ApiVersionExtensions.AddApiVersionRegistration"/>.
        /// If called directly from Startup class, don't forget to call <code>services.AddOptions();</code> first.
        /// </summary>
        /// <param name="services">Reference for <see cref="IServiceCollection"/></param>
        /// <param name="configuration">Configuration</param>
        /// <param name="typesForDocumentation">
        /// Collection of types. The assemblies of these types are looked into for Swagger documentation files.
        /// Make sure that all xml documentation files are copied to the API project's output.
        /// Can be used to load documentation from models outside the API project.
        /// </param>
        /// <returns></returns>
        public static IServiceCollection AddVersionedSwaggerRegistration(this IServiceCollection services, IConfiguration configuration, params Type[] typesForDocumentation)
        {
            services.Configure<ApiInformation>(configuration.GetSection(nameof(ApiInformation)));

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // integrate xml comments
                    foreach (var type in typesForDocumentation)
                    {
                        options.IncludeXmlComments(GetXmlCommentsFilePath(type));
                    }

                    // TODO add AddSecurityDefinition if you implement security
                    // https://github.com/domaindrivendev/Swashbuckle.AspNetCore#add-security-definitions-and-requirements
                });

            return services;
        }

        /// <summary>
        /// Adds a versioned API description and Swagger UI.
        /// </summary>
        /// <param name="app">Reference for <see cref="IApplicationBuilder"/>.</param>
        /// <param name="provider">Reference for <see cref="IApiVersionDescriptionProvider"/> to apply versioning.</param>
        /// <param name="swaggerRoutePrefix">Swagger options RoutePrefix, default string.Empty to serve Swagger at the application root.</param>
        /// <returns></returns>
        public static IApplicationBuilder AddVersionedSwaggerRegistration(this IApplicationBuilder app, IApiVersionDescriptionProvider provider,
            string swaggerRoutePrefix = "")
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                        options.RoutePrefix = swaggerRoutePrefix;
                    }

                    // TODO add security https://github.com/domaindrivendev/Swashbuckle.AspNetCore#enable-oauth20-flows
                });

            return app;
        }

        private static string GetXmlCommentsFilePath(Type type)
        {
            var xmlFile = $"{type.Assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            return xmlPath;
        }
    }
}
