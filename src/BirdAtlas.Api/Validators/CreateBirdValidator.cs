using System.Linq;
using BirdAtlas.Api.Models;
using FluentValidation;
using FluentValidation.Results;

namespace BirdAtlas.Api.Validators
{
    /// <summary>
    /// Sometimes you have more complex validators than those available through data annotations.
    /// </summary>
    public class CreateBirdValidator : AbstractValidator<CreateBirdCommand>
    {
        // of course this specific check could unneeded with enum values in the type
        private static readonly string[] AllowedPopulations = {"Extinct", "Threatened", "Stable"};

        public CreateBirdValidator()
        {
            RuleFor(x => x.Binomial).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Diet).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Nesting).NotEmpty().MaximumLength(20);

            RuleFor(x => x.Population).Custom((population, context) =>
            {
                if(!AllowedPopulations.Contains(population))
                    context.AddFailure(new ValidationFailure(nameof(CreateBirdCommand.Population), "Incorrect population value"));
            });
        }
    }
}
