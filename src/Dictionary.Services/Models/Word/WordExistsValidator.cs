using FluentValidation;

namespace Dictionary.Services.Models.Word
{
    public class WordExistsValidator : AbstractValidator<WordExistsServiceModel>
    {
        public WordExistsValidator()
        {
            RuleFor(x => x.LanguageId).Must(x => x > 0);
        }
    }
}