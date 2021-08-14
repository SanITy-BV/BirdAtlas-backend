using System;
using System.Collections.Generic;
using BirdAtlas.Api.Models;

namespace BirdAtlas.Api.Data
{
    /// <summary>
    /// Temporary data provider instead of fetching from a real database.
    /// Simplified for demo purposes.
    /// All content (except stories) from wikipedia.org.
    /// </summary>
    internal class BirdData
    {
        // blob container where images are stored
        private static string BlobUrl = "https://birdatlastemp.blob.core.windows.net/birds/";

        static BirdData()
        {
            // create more dummy stories
            // dummies
            for (int i = 0; i < 5; i++)
            {
                Stories.Add(new Story
                {
                    Id = Guid.NewGuid(),
                    Title = $"Bonus story {i}",
                    Author = "Generated",
                    Category = "Birdspotting",
                    Content = "Birdwatching, or birding, is the observing of birds, either as a recreational activity or as a form of citizen science. A birdwatcher may observe by using their naked eye, by using a visual enhancement device like binoculars or a telescope, by listening for bird sounds, or by watching public webcams.\r\nBirdwatching often involves a significant auditory component, as many bird species are more easily detected and identified by ear than by eye.Most birdwatchers pursue this activity for recreational or social reasons, unlike ornithologists, who engage in the study of birds using formal scientific methods.",
                    ImageUrl = BlobUrl + "Story1.jpg",
                    IsFeatured = false,
                    PublishedOn = new DateTime(2018, 7, 1),
                });
            }
        }

        public static List<Family> Families { get; } = new List<Family>
        {
            new Family
            {
                Id = Guid.NewGuid(),
                Name = "Alcedinidae",
                Description =
                    "Kingfishers or Alcedinidae are a family of small to medium-sized, brightly colored birds in the order Coraciiformes. They have a cosmopolitan distribution, with most species found in the tropical regions of Africa, Asia, and Oceania. The family contains 114 species and is divided into three subfamilies and 19 genera. All kingfishers have large heads, long, sharp, pointed bills, short legs, and stubby tails. Most species have bright plumage with only small differences between the sexes. Most species are tropical in distribution, and a slight majority are found only in forests."
            },
            new Family
            {
                Id = Guid.NewGuid(),
                Name = "Hirundinidae",
                Description =
                    "The swallows, martins, and saw-wings, or Hirundinidae, are a family of passerine birds found around the world on all continents, including occasionally in Antarctica. Highly adapted to aerial feeding, they have a distinctive appearance. The term 'swallow' is used colloquially in Europe as a synonym for the barn swallow. Around 90 species of Hirundinidae are known, divided into 19 genera, with the greatest diversity found in Africa, which is also thought to be where they evolved as hole-nesters."
            },
            new Family
            {
                Id = Guid.NewGuid(),
                Name = "Phasianidae",
                Description = "The Phasianidae are a family of heavy, ground-living birds, which includes pheasants, partridges, junglefowl, chickens, turkeys, Old World quail, and peafowl. The family includes many of the most popular gamebirds."
            }
        };

        public static List<Habitat> Habitats { get; } = new List<Habitat>
        {
            new Habitat
            {
                Type = HabitatType.Wetland,
                Name = "Wetland - Lakes",
                BirdCount = 2
            }
        };

        public static List<Bird> Birds { get; } = new List<Bird>
        {
            new Bird
            {
                Id = Guid.NewGuid(),
                Name = "Common kingfisher",
                Binomial = "Alcedo atthis",
                FamilyId = Families[0].Id,
                Family = Families[0].Name,
                Description =
                    "The common kingfisher (Alcedo atthis), also known as the Eurasian kingfisher and river kingfisher, is a small kingfisher with seven subspecies recognized within its wide distribution across Eurasia and North Africa. It is resident in much of its range, but migrates from areas where rivers freeze in winter.",
                ImageUrl = BlobUrl + "Common_Kingfisher.jpg",
                Habitat = HabitatType.Wetland,
                Diet = "Fish",
                Nesting = "Burrow",
                Population = "Stable",
                Location = "Eurasia and North Africa"
            },
            new Bird
            {
                Id = Guid.NewGuid(),
                Name = "Cerulean kingfisher",
                Binomial = "Alcedo coerulescens",
                FamilyId = Families[0].Id,
                Family = Families[0].Name,
                Description =
                    "The cerulean kingfisher (Alcedo coerulescens) is a kingfisher in the subfamily Alcedininae which is found in parts of Indonesia. With an overall metallic blue impression, it is very similar to the common kingfisher, but it is white underneath instead of orange.",
                ImageUrl = BlobUrl + "Cerulean_Kingfisher.jpg",
                Habitat = HabitatType.Wetland,
                Diet = "Fish",
                Nesting = "Burrow",
                Population = "Stable",
                Location = "Indonesia"
            },
            // swallows
            new Bird
            {
                Id = Guid.NewGuid(),
                Name = "Red-breasted swallow",
                Binomial = "Cecropis semirufa",
                FamilyId = Families[1].Id,
                Family = Families[1].Name,
                Description =
                    "The red-breasted swallow (Cecropis semirufa), also known as the rufous-chested swallow, is a member of the family Hirundinidae, found in Sub-Saharan Africa. It is confined to the tropical rainforest during the wet season.",
                ImageUrl = BlobUrl + "Red-breasted_Swallow.jpg",
                Habitat = HabitatType.UrbanSuburban,
                Diet = "Insects",
                Nesting = "Mud nest",
                Population = "Stable",
                Location = "Sub-Saharan Africa"
            },
            new Bird
            {
                Id = Guid.NewGuid(),
                Name = "Blue-and-white swallow",
                Binomial = "Pygochelidon cyanoleuca",
                FamilyId = Families[1].Id,
                Family = Families[1].Name,
                Description =
                    "The blue-and-white swallow (Pygochelidon cyanoleuca) is a passerine bird that breeds from Nicaragua south throughout South America, except in the deserts and the Amazon Basin. The southern race is migratory, wintering as far north as Trinidad, where it is a regular visitor. The nominate northern race may have bred on that island.",
                ImageUrl = BlobUrl + "Blue-white_swallow.jpg",
                Habitat = HabitatType.UrbanSuburban,
                Diet = "Insects",
                Nesting = "Straw nest",
                Population = "Stable",
                Location = "South America"
            },
            new Bird
            {
                Id = Guid.NewGuid(),
                Name = "Hazel grouse",
                Binomial = "Tetrastes bonasia",
                FamilyId = Families[2].Id,
                Family = Families[2].Name,
                Description =
                    "The hazel grouse (Tetrastes bonasia), sometimes called the hazel hen, is one of the smaller members of the grouse family of birds. It is a sedentary species, breeding across the Palearctic as far east as Hokkaido, and as far west as eastern and central Europe, in dense, damp, mixed coniferous woodland, preferably with some spruce. The bird is sometimes referred to as 'rabchick' (from рябчик) by early 20th century English speaking travellers to Russia.",
                ImageUrl = BlobUrl + "Hazel_Grouse.jpg",
                Habitat = HabitatType.Forest,
                Diet = "Plants & Insects",
                Nesting = "Ground nest",
                Population = "Stable",
                Location = "Palearctic"
            },
        };

        public static List<Story> Stories { get; } = new List<Story>
        {
            new Story
            {
                Id = Guid.NewGuid(),
                Title = "Kingdom of Belgium",
                Author = "Dirk Raes",
                Category = "Birdspotting",
                Content =
                    "Belgium is probably not the best country for birding, although there are Belgian Hotspots. You will probably expect flocks of geese grazing the polders, but may be surprised to know that the wooded hillsides in the East of the country can hold Hazel Grouse and Tengmalm’s Owl.",
                ImageUrl = BlobUrl + "Story1.jpg",
                IsFeatured = true,
                PublishedOn = new DateTime(2018, 7, 1),
                RelatedBirds = new List<RelatedBird>
                {
                    new RelatedBird
                    {
                        Id = Birds[4].Id,
                        Name = Birds[4].Name,
                        ImageUrl = Birds[4].ImageUrl,
                    }
                }
            }
        };
    }
}
