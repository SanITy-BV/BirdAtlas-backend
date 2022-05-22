using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BirdAtlas.Api.Models
{
    /// <summary>
    /// Model with required properties to update the changeable bird properties.
    /// </summary>
    [ApiVersion("2.0")]
    public class UpdateBirdCommand
    {
        /// <summary>
        /// Bird's habitat.
        /// </summary>
        [Required]
        public HabitatType Habitat { get; set; }

        /// <summary>
        /// Bird's diet.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Diet { get; set; }

        /// <summary>
        /// Bird's nesting habits.
        /// </summary>
        [Required]
        [MaxLength(20)]
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
