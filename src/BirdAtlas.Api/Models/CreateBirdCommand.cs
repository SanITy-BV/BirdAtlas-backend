using System;

namespace BirdAtlas.Api.Models
{
    public class CreateBirdCommand
    {
        public string Binomial { get; set; }
        public Guid HabitatId { get; set; }
        public string Diet { get; set; }
        public string Nesting { get; set; }
        public string Population { get; set; }
        public string ImageUrl { get; set; }
    }
}
