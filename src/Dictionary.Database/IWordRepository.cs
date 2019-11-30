using Dictionary.Database.Models;
using System.Collections.Generic;

namespace Dictionary.Database
{
    public interface IWordRepository
    {
        void Create(Word word);

        List<Word> List(int languageId);
    }
}
