using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using BirdAtlas.Api.ConfigurationExtensions;
using BirdAtlas.Api.Middleware;
using BirdAtlas.Api.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace BirdAtlas.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string domain = "atlas"; // prefix that you can use to divide APIs in 'domains'. Can come from appsettings.

            // Starting from Microsoft.ApplicationInsights.AspNetCore version 2.15.0, calling services.AddApplicationInsightsTelemetry() will automatically read the instrumentation key 
            // from Microsoft.Extensions.Configuration.IConfiguration of the application. There is no need to explicitly provide the IConfiguration.
            services.AddApplicationInsightsTelemetry();

            services
                .AddControllers(options =>
                {
                    options.UseGlobalRoutePrefix(new RouteAttribute(domain + "/v{version:apiVersion}"));
                })
                .AddJsonOptions(opts =>
                {
                    var enumConverter = new JsonStringEnumConverter();
                    opts.JsonSerializerOptions.Converters.Add(enumConverter);
                })
                // .AddNewtonsoftJson(opts => opts.Converters.Add(new StringEnumConverter())); // or use Newtonsoft.Json
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBirdValidator>(
                        lifetime: ServiceLifetime.Singleton));

            services.AddHealthCheckConfiguration(Configuration);

            services.AddOptions();
            // moved API version and Swagger config in separate classes to keep Startup clean
            services.AddApiVersionRegistration();
            services.AddVersionedSwaggerRegistration(Configuration, typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler(errorHandler => errorHandler.UseMiddleware<GlobalExceptionHandlerMiddleware>());
            }

            // moved UseSwagger / UseSwaggerUI in separate method
            app.AddVersionedSwaggerRegistration(provider);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
