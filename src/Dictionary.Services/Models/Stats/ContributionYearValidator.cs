using FluentValidation;

namespace Dictionary.Services.Models.Stats
{
    public class ContributionYearValidator : AbstractValidator<ContributionYear>
    {
        public ContributionYearValidator()
        {
            RuleFor(x => x).Must(x => x.Year > 2019);
            RuleFor(x => x).Must(x => x.Year < 2030);
        }
    }
}