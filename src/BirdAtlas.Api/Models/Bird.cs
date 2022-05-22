using System;

namespace BirdAtlas.Api.Models
{
    public class Bird
    {
        /// <summary>
        /// Unique identifier of a bird in the system.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Bird's public name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Bird's binomial name.
        /// </summary>
        public string Binomial { get; set; }

        /// <summary>
        /// Id of the Bird's family classification.
        /// </summary>
        public Guid FamilyId { get; set; }

        /// <summary>
        /// Name of the Bird's family classification.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// General description of the bird.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Url to an image of the bird.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Bird's habitat.
        /// </summary>
        public HabitatType Habitat { get; set; }

        /// <summary>
        /// Bird's diet.
        /// </summary>
        public string Diet { get; set; }

        /// <summary>
        /// Bird's nesting habits.
        /// </summary>
        public string Nesting { get; set; }

        /// <summary>
        /// Bird's population size, conservation status.
        /// </summary>
        public string Population { get; set; }

        /// <summary>
        /// Worldwide regions where the bird lives.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// List of recent spottings by the app's users.
        /// </summary>
        public int RecentSpottings { get; set; }

        /// <summary>
        /// Is this bird one of your favorites?
        /// </summary>
        public bool Favorited { get; set; }
    }
}
