using Dictionary.Services.Models;
using Dictionary.Shared.Filters;

namespace Dictionary.Services.ServiceValiators.Word
{
    public interface IWordServiceValidator
    {
        ServiceError ValidateWordFilterModel(WordFilterModel model);
    }
}
