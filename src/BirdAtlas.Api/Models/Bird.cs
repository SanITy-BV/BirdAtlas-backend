using System;

namespace BirdAtlas.Api.Models
{
    public class Bird
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Binomial { get; set; }
        public Guid FamilyId { get; set; }
        public string Family { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public HabitatType Habitat { get; set; }

        public string Diet { get; set; }
        public string Nesting { get; set; }
        public string Population { get; set; }
        public string Location { get; set; }
        public int RecentSpottings { get; set; }
        public bool Favorited { get; set; }
    }
}
