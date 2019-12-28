using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Database.Models;

namespace Dictionary.Database.Repositories.Word
{
    public interface IWordRepository
    {
        Task CreateAsync(WordDto word);

        List<WordDto> List(int languageId);
    }
}
