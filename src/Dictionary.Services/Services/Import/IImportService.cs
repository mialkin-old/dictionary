using System.IO;
using System.Threading.Tasks;

namespace Dictionary.Services.Services.Import
{
    public interface IImportService
    {
        Task ImportWordsAsync(Stream ms);
    }
}
