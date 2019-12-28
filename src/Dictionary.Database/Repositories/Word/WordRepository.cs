using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Database.Models;

namespace Dictionary.Database.Repositories.Word
{
    public class WordRepository : IWordRepository
    {
        public WordRepository(DictionaryDb db)
        {
            Db = db;
        }
        public DictionaryDb Db { get; }

        public async Task CreateAsync(WordDto word)
        {
            Db.Add(word);
            await Db.SaveChangesAsync();
        }

        public List<WordDto> List(int languageId)
        {
            return Db.Words.ToList();
        }
    }
}
