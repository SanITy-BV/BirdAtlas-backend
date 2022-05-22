using System;
using System.Collections.Generic;

namespace BirdAtlas.Api.Models
{
    public class Story
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public List<RelatedBird> RelatedBirds { get; set; }
    }
}
