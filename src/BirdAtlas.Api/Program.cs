using System.Reflection;
using System.Text.Json.Serialization;
using BirdAtlas.Api.Configuration;
using BirdAtlas.Api.ConfigurationExtensions;
using BirdAtlas.Api.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BirdAtlas.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string domain = "atlas";
            builder.Services
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

            builder.Services.AddEndpointsApiExplorer(); // created to support Minimal API, see https://stackoverflow.com/questions/71932980/what-is-addendpointsapiexplorer-in-asp-net-core-6

            builder.Services.AddOptions();
            builder.Services.Configure<ApiInformation>(builder.Configuration.GetSection(nameof(ApiInformation)));

            // moved API version and Swagger config in separate classes to keep Program clean
            builder.Services.AddApiVersionRegistration();
            builder.Services.AddVersionedSwaggerRegistration(builder.Configuration, typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // added for debugging purposes
            }

            app.UseVersionedSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}