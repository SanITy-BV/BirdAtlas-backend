using System;
using System.Collections.Generic;
using System.Linq;
using BirdAtlas.Api.Data;
using BirdAtlas.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BirdAtlas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HabitatsController : ControllerBase
    {
        private readonly ILogger<HabitatsController> _logger;

        public HabitatsController(ILogger<HabitatsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Habitat> List()
        {
            return BirdData.Habitats;
        }

        [HttpGet("{type}/birds")]
        public IEnumerable<Bird> GetBirds(string type)
        {
            return BirdData.Birds.Where(b => b.Habitat == Enum.Parse<HabitatType>(type, ignoreCase: true));
        }
    }
}
