using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using BirdAtlas.Api.Data;
using BirdAtlas.Api.Models;

namespace BirdAtlas.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController : ControllerBase
    {
        private readonly ILogger<FamiliesController> _logger;

        public FamiliesController(ILogger<FamiliesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Family> List()
        {
            return BirdData.Families;
        }

        [HttpGet("{id}/birds")]
        public IEnumerable<Bird> GetBirds(Guid id)
        {
            return BirdData.Birds.Where(b => b.FamilyId == id);
        }
    }
}
