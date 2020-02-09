using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Services.Models.Word;
using Dictionary.Shared.Filters.Word;

namespace Dictionary.Services.Services.Word
{
    public interface IWordService
    {
        Task<IList<WordListServiceModel>> ListAsync(WordListFilter filter);
        
        Task<int> CreateAsync(WordCreateServiceModel model);

        Task UpdateAsync(WordUpdateServiceModel model);

        Task DeleteAsync(int id);

        Task<bool> WordExists(string name, int languageId);
    }
}
