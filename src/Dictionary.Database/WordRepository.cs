using System.Collections.Generic;
using System.Linq;
using Dictionary.Database.Models;

namespace Dictionary.Database
{
    public class WordRepository : IWordRepository
    {
        public WordRepository(DictionaryDb db)
        {
            Db = db;
        }

        public DictionaryDb Db { get; }

        public void Create(Word word)
        {
            Db.Add(word);
            Db.SaveChanges();
        }

        public List<Word> List(int languageId)
        {
            return Db.Words.ToList();
        }
    }
}
