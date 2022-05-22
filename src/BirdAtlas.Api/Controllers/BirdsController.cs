using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using BirdAtlas.Api.Data;
using BirdAtlas.Api.Models;
using Microsoft.AspNetCore.Http;

namespace BirdAtlas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BirdsController : ControllerBase
    {
        private readonly ILogger<BirdsController> _logger;

        public BirdsController(ILogger<BirdsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Bird> List(int page = 0, int amount = 20)
        {
            // simply using the temporary in-memory data provider.
            // options here depend on the chosen architecture:
            // - multiple layers (= go to 'manager' or 'service' which in turn goes to 'repository')
            // - CQRS: QueryHandler or straight into 'repository)
            // Also look at https://github.com/davidfowl/dotnet6minimalapi/blob/main/Dotnet6_Minimal_API/Program.cs for minimal API
            return BirdData.Birds.Skip(page * amount).Take(amount);
        }

        [HttpGet("{id}")]
        public Bird Get(Guid id)
        {
            return BirdData.Birds.SingleOrDefault(b => b.Id == id);
        }

        [HttpPost]
        public CreatedAtActionResult Create([FromBody] CreateBirdCommand createBirdCommand)
        {
            Bird newBird = new Bird {Id = Guid.NewGuid()}; // TODO map + insert
            return CreatedAtAction(nameof(Get), new {id = newBird.Id}, newBird);
        }

        [HttpPut("{id}")]
        public OkResult Update(Guid id, [FromBody]Bird bird)
        {
            return Ok();
        }

        [HttpPut("{id}/favorite")]
        public OkResult Favorite(Guid id, bool favorite)
        {
            // this should of course be account-specific instead of shared once we save state
            var bird = BirdData.Birds.SingleOrDefault(b => b.Id == id);
            bird.Favorited = favorite; // should check null and return 404, but used as exception demo.
            return Ok();
        }
    }
}
