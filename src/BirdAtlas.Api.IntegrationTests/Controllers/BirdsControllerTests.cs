using System.Collections.Generic;
using System.Threading.Tasks;
using BirdAtlas.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace BirdAtlas.Api.IntegrationTests.Controllers
{
    /// <summary>
    /// Note: integration test with WebApplicationFactory<Program>
    /// This works since we have a Program class defined, in case you're using top-level statements (no Program class),
    /// you'll need to add the line below in your API.
    ///
    ///     + public partial class Program { }
    ///
    /// More info: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0&WT.mc_id=WDIT-MVP-5001715
    /// </summary>
    public class BirdsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BirdsControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Birds_ShouldReturn_NotEmptyCollection()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/atlas/v1/birds");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Bird>>(content);

            Assert.NotEmpty(result);
        }
    }
}