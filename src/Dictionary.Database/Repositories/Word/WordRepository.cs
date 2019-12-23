using System.Collections.Generic;
using System.Linq;
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

        public void Create(WordDbModel word)
        {
            Db.Add(word);
            Db.SaveChanges();
        }

        public List<WordDbModel> List(int languageId)
        {
            return Db.Words.ToList();
        }
    }
}
