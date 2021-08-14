/*
 * Source: https://github.com/Microsoft/aspnet-api-versioning/blob/master/samples/aspnetcore/SwaggerSample/ConfigureSwaggerOptions.cs
 * Modified to support Swagger v5, and be extendable.
 */

using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BirdAtlas.Api.Configuration
{
    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly ApiInformation _apiInformation;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="apiInformation">The <see cref="ApiInformation"/> config section</param>
        public ConfigureSwaggerOptions(IOptions<ApiInformation> apiInformation)
        {
            _apiInformation = apiInformation?.Value;

            if (_apiInformation == null)
                throw new ArgumentNullException(nameof(apiInformation), "Missing config section");
        }

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", CreateInfoForApiVersion());
        }

        private OpenApiInfo CreateInfoForApiVersion()
        {
            var primaryContact = _apiInformation.Contacts.FirstOrDefault(p => p.IsPrimary) ?? _apiInformation.Contacts.FirstOrDefault();

            var info = new OpenApiInfo
            {
                Title = _apiInformation.Title,
                Version = "v1",
                Description = _apiInformation.Description,
                Contact = new OpenApiContact { Name = primaryContact?.Name, Email = primaryContact?.Email },
                TermsOfService = !string.IsNullOrWhiteSpace(_apiInformation.TermsOfServiceUri) ?
                    new Uri(_apiInformation.TermsOfServiceUri) : null,
                License = !string.IsNullOrWhiteSpace(_apiInformation.LicenseUri) ?
                    new OpenApiLicense { Name = _apiInformation.LicenseName, Url = new Uri(_apiInformation.LicenseUri) } : null
            };

            return info;
        }
    }
}
