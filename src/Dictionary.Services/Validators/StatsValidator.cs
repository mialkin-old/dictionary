using FluentValidation;

namespace Dictionary.Services.Validators
{
    public class StatsValidator : AbstractValidator<int?>
    {
        public StatsValidator()
        {
            RuleFor(x => x).Must(x => x > 2019);
            RuleFor(x => x).Must(x => x < 2030);
        }
    }
}