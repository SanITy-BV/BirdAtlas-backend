using BirdAtlas.Api.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BirdAtlas.Api.ConfigurationExtensions
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheckConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string dbName = "birdatlasdb";
            services.AddHealthChecks()
                .AddCheck("BirdAtlasDb", new SqlConnectionHealthCheck(configuration.GetConnectionString(dbName)),
                    HealthStatus.Unhealthy,
                    new string[] { dbName });
            // add check for each dependency

            return services;
        }
    }
}
