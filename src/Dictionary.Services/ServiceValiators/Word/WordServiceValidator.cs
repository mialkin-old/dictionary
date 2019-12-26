using Dictionary.Services.Exceptions;
using Dictionary.Shared.Filters;

namespace Dictionary.Services.ServiceValiators.Word
{
    public class WordServiceValidator: IWordServiceValidator
    {
        public void ValidateWordFilterModel(WordFilterModel model)
        {
            if(model.LanguageId == null)
                throw new ServiceValidatorException("Не указан язык выборки");
        }
    }
}
