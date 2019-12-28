using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Database.Models;
using Dictionary.Shared.Filters.Word;

namespace Dictionary.Database.Repositories.Word
{
    public interface IWordRepository
    {
        Task CreateAsync(WordDto word);

        Task<IList<WordDto>> ListAsync(WordListFilter filter);
    }
}
