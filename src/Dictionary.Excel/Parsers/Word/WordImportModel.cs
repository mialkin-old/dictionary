using System;

namespace Dictionary.Excel.Parsers.Word
{
    public class WordImportModel
    {
        public int WordId { get; set; }

        public string Name { get; set; }

        public string Translation { get; set; }

        public string Transcription { get; set; }

        public int LanguageId { get; set; }

        public int GenderId { get; set; }

        public DateTime Created { get; set; }
    }
}
