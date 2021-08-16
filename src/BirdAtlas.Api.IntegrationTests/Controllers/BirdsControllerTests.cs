using System.Collections.Generic;
using System.Threading.Tasks;
using BirdAtlas.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace BirdAtlas.Api.IntegrationTests.Controllers
{
    public class BirdsControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BirdsControllerTests(WebApplicationFactory<Startup> factory)
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
