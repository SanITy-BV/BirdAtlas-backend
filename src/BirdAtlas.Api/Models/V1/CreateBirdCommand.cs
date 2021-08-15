namespace BirdAtlas.Api.Models
{
    /// <summary>
    /// Model with required properties to create a new bird registration.
    /// </summary>
    public class CreateBirdCommand
    {
        /// <summary>
        /// Bird's binomial name.
        /// </summary>
        public string Binomial { get; set; }

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
        /// Url of an image of the bird.
        /// Note: app could support image upload and fill this automatically server side.
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
