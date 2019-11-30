using Dictionary.Database;
using Dictionary.Database.Models;
using Dictionary.Services.Models.Word;


namespace Dictionary.Services
{
    public class WordService : IWordService
    {
        public void Create(WordCreate word)
        {
            IWordRepository repository = new WordRepository();
            repository.Create(new Word { Name = word.Name });
        }
    }
}
