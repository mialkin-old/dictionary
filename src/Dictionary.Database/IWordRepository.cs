using Dictionary.Database.Models;

namespace Dictionary.Database
{
    public interface IWordRepository
    {
        void Create(Word word);
    }
}
