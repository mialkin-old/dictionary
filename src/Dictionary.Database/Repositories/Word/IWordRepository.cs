using System.Collections.Generic;

namespace Dictionary.Database.Repositories.Word
{
    public interface IWordRepository
    {
        void Create(Models.WordDbModel word);

        List<Models.WordDbModel> List(int languageId);
    }
}
