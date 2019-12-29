using System;

namespace Dictionary.Services.Models.Word
{
    public class WordImportServiceModel
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
