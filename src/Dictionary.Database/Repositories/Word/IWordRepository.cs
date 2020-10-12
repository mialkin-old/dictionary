using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Database.Models;
using Dictionary.Shared.Filters;

namespace Dictionary.Database.Repositories.Word
{
    public interface IWordRepository : IRepository<WordDto>
    {
        Task CreateAsync(IEnumerable<WordDto> word);

        Task UpdateAsync(WordDto word);

        Task<WordDto> GetByNameAsync(string name, int languageId);

        Task<IList<WordDto>> ListAsync(WordListFilter filter);

        Task<IList<WordDto>> SearchAsync(WordSearchFilter filter);
    }
}
