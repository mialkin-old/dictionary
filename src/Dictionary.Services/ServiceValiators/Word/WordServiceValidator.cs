using System;
using Dictionary.Services.Models;
using Dictionary.Shared.Filters;

namespace Dictionary.Services.ServiceValiators.Word
{
    public class WordServiceValidator: IWordServiceValidator
    {
        public ServiceError ValidateWordFilterModel(WordFilterModel model)
        {
            if(model.LanguageId == null)
                return new ServiceError("Не указан язык выборки");

            return null;
        }
    }
}
