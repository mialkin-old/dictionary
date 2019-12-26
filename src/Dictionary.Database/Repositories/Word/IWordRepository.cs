using System.Collections.Generic;
using Dictionary.Database.Models;

namespace Dictionary.Database.Repositories.Word
{
    public interface IWordRepository
    {
        void Create(WordDbModel word);

        List<WordDbModel> List(int languageId);
    }
}
