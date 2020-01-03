using System.Collections.Generic;
using Dictionary.Excel.Parsers;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Dictionary.Database.Models;
using Dictionary.Database.Repositories.Word;
using Dictionary.Excel.Parsers.Word;

namespace Dictionary.Services.Services.Import
{
    public class ImportService : IImportService
    {
        private readonly IExcelParser<WordImportModel> _excelParser;
        private readonly IWordRepository _wordRepository;
        private readonly IMapper _mapper;

        public ImportService(IExcelParser<WordImportModel> excelParser, IWordRepository wordRepository, IMapper mapper)
        {
            _excelParser = excelParser;
            _wordRepository = wordRepository;
            _mapper = mapper;
        }
        public async Task ImportWordsAsync(Stream ms)
        {
            IEnumerable<WordImportModel> result = _excelParser.Initialize(ms).Parse();

            await _wordRepository.CreateAsync(_mapper.Map<IEnumerable<WordDto>>(result));
        }
    }
}
