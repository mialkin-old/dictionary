using System.Collections.Generic;
using System.Linq;

namespace Dictionary.Database.Repositories.Word
{
    public class WordRepository : IWordRepository
    {
        public WordRepository(DictionaryDb db)
        {
            Db = db;
        }
        public DictionaryDb Db { get; }

        public void Create(Models.WordDbModel word)
        {
            Db.Add(word);
            Db.SaveChanges();
        }

        public List<Models.WordDbModel> List(int languageId)
        {
            return Db.Words.ToList();
        }
    }
}
