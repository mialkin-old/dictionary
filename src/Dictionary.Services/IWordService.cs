using Dictionary.Services.Models.Word;

namespace Dictionary.Services
{
    public interface IWordService
    {
        void Create(WordCreate word);
    }
}
