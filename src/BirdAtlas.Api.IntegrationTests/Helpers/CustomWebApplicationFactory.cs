using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BirdAtlas.Api.IntegrationTests.Helpers
{
    /// <summary>
    /// In case you need custom services configured. More info see: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0&WT.mc_id=WDIT-MVP-5001715
    /// </summary>
    /// <typeparam name="TStartup"></typeparam>
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // modify the configured services, e.g. move to a in memory db


                //var descriptor = services.SingleOrDefault(
                //    d => d.ServiceType ==
                //         typeof(DbContextOptions<ApplicationDbContext>));

                //services.Remove(descriptor);

                //services.AddDbContext<ApplicationDbContext>(options =>
                //{
                //    options.UseInMemoryDatabase("InMemoryDbForTesting");
                //});

                //var sp = services.BuildServiceProvider();

                //using (var scope = sp.CreateScope())
                //{
                //    var scopedServices = scope.ServiceProvider;
                //    var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                //    var logger = scopedServices
                //        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                //    db.Database.EnsureCreated();

                //    try
                //    {
                //        Utilities.InitializeDbForTests(db);
                //    }
                //    catch (Exception ex)
                //    {
                //        logger.LogError(ex, "An error occurred seeding the " +
                //                            "database with test messages. Error: {Message}", ex.Message);
                //    }
                //}
            });
        }
    }
}