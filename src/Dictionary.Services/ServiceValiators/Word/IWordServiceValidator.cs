using Dictionary.Services.Models;
using Dictionary.Shared.Filters;

namespace Dictionary.Services.ServiceValiators.Word
{
    public interface IWordServiceValidator
    {
        void ValidateWordFilterModel(WordFilterModel model);
    }
}
