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
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    [Route("[controller]")]
    public class BirdsController : ControllerBase
    {
        private readonly ILogger<BirdsController> _logger;

        public BirdsController(ILogger<BirdsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retrieve a list of birds.
        /// </summary>
        /// <param name="page">Page count</param>
        /// <param name="amount">Amount of birds per page</param>
        /// <returns></returns>
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

        /// <summary>
        /// Get a single bird
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>A bird if found</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Bird))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Bird> Get(Guid id)
        {
            var bird = BirdData.Birds.SingleOrDefault(b => b.Id == id);
            if (bird == null)
            {
                _logger.LogWarning("Get Bird with invalid Id");
                return NotFound();
            }

            return bird;
        }

        /// <summary>
        /// Register a new bird
        /// </summary>
        /// <param name="createBirdCommand">Required properties of a bird</param>
        /// <returns>Bird object and location where to find the bird</returns>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Bird))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Create([FromBody] CreateBirdCommand createBirdCommand)
        {
            Bird newBird = new Bird {Id = Guid.NewGuid()}; // TODO map + insert
            return CreatedAtAction(nameof(Get), new {id = newBird.Id}, newBird);
        }

        /// <summary>
        /// Update the properties of a bird
        /// </summary>
        /// <param name="id">Bird's id</param>
        /// <param name="bird">Complete bird object, no PATCH is supported.</param>
        /// <returns></returns>
        [Obsolete]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public IActionResult UpdateDeprecated(Guid id, [FromBody]Bird bird)
        {
            return Ok();
        }

        /// <summary>
        /// Update the properties of a bird
        /// </summary>
        /// <param name="id">Bird's id</param>
        /// <param name="updateBirdCommand">Updateable properties of a bird, no PATCH is supported.</param>
        /// <returns></returns>
        [ApiVersion("2.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateBirdCommand updateBirdCommand)
        {
            return Ok();
        }

        /// <summary>
        /// Mark a bird as your favorite
        /// </summary>
        /// <param name="id">Bird's id</param>
        /// <param name="favorite">Favorited value</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}/favorite")]
        public IActionResult Favorite(Guid id, bool favorite)
        {
            // this should of course be account-specific instead of shared once we save state
            var bird = BirdData.Birds.SingleOrDefault(b => b.Id == id);
            bird.Favorited = favorite; // should check null and return 404, but used as exception demo.
            return Ok();
        }
    }
}
