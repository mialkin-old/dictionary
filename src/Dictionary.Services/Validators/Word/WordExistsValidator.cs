using Dictionary.Services.Models.Word;
using FluentValidation;

namespace Dictionary.Services.Validators.Word
{
    public class WordExistsValidator : AbstractValidator<WordExistsSm>
    {
        public WordExistsValidator()
        {
            RuleFor(x => x.LanguageId).Must(x => x > 0);
            //RuleFor(x => x).Must(x => x < 2030);
        }
    }
}