using System.Collections.Generic;
using System.Linq;
using Dictionary.Database.Models;

namespace Dictionary.Database
{
    public class WordRepository : IWordRepository
    {
        public void Create(Word word)
        {
            using (var db = new DictionaryDb())
            {
                db.Add(word);
                db.SaveChanges();
            }
        }

        public List<Word> List(int languageId)
        {
            using (var db = new DictionaryDb())
            {
                return db.Words.ToList();
            }
        }
    }
}
