using FluentValidation;

namespace Dictionary.Services.Models.Stats
{
    public class ContributionYearModelValidator : AbstractValidator<ContributionYearModel>
    {
        public ContributionYearModelValidator()
        {
            RuleFor(x => x).Must(x => x.Year > 2019);
            RuleFor(x => x).Must(x => x.Year < 2030);
        }
    }
}