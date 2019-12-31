using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Database.ExtensionMethods;
using Dictionary.Database.Models;
using Dictionary.Shared.Filters.Word;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.Database.Repositories.Word
{
    public class WordRepository : IWordRepository
    {
        public WordRepository(DictionaryDb db)
        {
            Db = db;
        }
        public DictionaryDb Db { get; }

        // Подумать над вынесением в RepositoryBase.
        public async Task CreateAsync(WordDto word)
        {
            Db.Add(word);
            await Db.SaveChangesAsync();
        }

        public async Task<IList<WordDto>> ListAsync(WordListFilter filter)
        {
            var result = await Db.Words
                .ApplyWordListFilter(filter)
                .ToListAsync();

            return result;
        }
    }
}
