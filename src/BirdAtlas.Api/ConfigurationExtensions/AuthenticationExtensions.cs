using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;

namespace BirdAtlas.Api.ConfigurationExtensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAadRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"));
            JwtSecurityTokenHandler.DefaultMapInboundClaims = true; // true is default

            // The following lines code instruct the asp.net core middleware to use the data in the "roles" claim in the Authorize attribute and User.IsInrole()
            // See https://docs.microsoft.com/aspnet/core/security/authorization/roles?view=aspnetcore-2.2 for more info.
            services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                // The claim in the Jwt token where App roles are available.
                options.TokenValidationParameters.RoleClaimType = "roles";
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "CORSPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200") // your Angular port
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            return services;
        }
    }
}
