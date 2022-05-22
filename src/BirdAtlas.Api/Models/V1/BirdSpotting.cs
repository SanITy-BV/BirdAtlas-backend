using System;

namespace BirdAtlas.Api.Models
{
    public class BirdSpotting
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string SpottedBy { get; set; }
        public string ImageUrl { get; set; }
    }
}
