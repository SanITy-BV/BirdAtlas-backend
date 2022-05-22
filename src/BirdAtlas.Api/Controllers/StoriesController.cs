using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using BirdAtlas.Api.Data;
using BirdAtlas.Api.Models;

namespace BirdAtlas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly ILogger<StoriesController> _logger;

        public StoriesController(ILogger<StoriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Story> List(int page, int amount = 20)
        {
            return BirdData.Stories.Skip(page * amount).Take(amount);
        }

        [HttpGet("featured")]
        public IEnumerable<Story> Featured(int amount = 4)
        {
            return BirdData.Stories.Where(s => s.IsFeatured).Take(amount);
        }
    }
}
